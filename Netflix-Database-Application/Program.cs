//
// Project #06
// 
// SQL, C# and ADO.NET program to retrieve Netflix movie data.
//
// Omar Salas-Rodriguez
// 

using System;
using System.Data.SqlClient;
using System.Data;

namespace workspace
{
  class Program
  {
    
    //
    // Main:
    //
    static void Main(string[] args)
    {
      string connectionInfo = String.Format(@"
Server=tcp:jhummel2.database.windows.net,1433;Initial Catalog=Netflix;
Persist Security Info=False;User ID=student;Password=cs341!uic;
MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
Connection Timeout=30;
");
      

    // Initialize all variables to default values
    SqlConnection db = null; // Database object needs try-catch
    string input = "", sqlReviews = "", movieName = "", movieYear = "";
    int rank = 0, totalReviews = 0;
    double avgRating = 0.0;
    // DataSet objects for the data to be held
    DataSet reviewsDS = new DataSet();
    DataSet ranksDS = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adapter;
    DataRowCollection reviewRows = null, rankRows = null; // Get all the rows in the first table
    int numReviewRows = 0, numRankRows = 0;
    
    // SQL Query to get all the average ratings and order them in descending order to get the rank
    // Also gets the movie year and name
    // This Query includes all those movies who have no rank replacing the average value with DBNull
    string sqlRank = string.Format(@"
    SELECT Movies.MovieName, Movies.MovieYear,
        ((R.Fives*5) + (R.Fours*4) + (R.Threes*3) + (R.Twos*2) + (R.Ones)) / CAST(R.TotalReviews AS FLOAT) AS AvgRating
    FROM (
        SELECT 
            Movies.MovieID,
            Count(*) AS TotalReviews,
            Sum(CASE WHEN Reviews.Rating = '5' THEN 1 ELSE 0 END) AS Fives,
            Sum(CASE WHEN Reviews.Rating = '4' THEN 1 ELSE 0 END) AS Fours,
            Sum(CASE WHEN Reviews.Rating = '3' THEN 1 ELSE 0 END) AS Threes,
            Sum(CASE WHEN Reviews.Rating = '2' THEN 1 ELSE 0 END) AS Twos,
            Sum(CASE WHEN Reviews.Rating = '1' THEN 1 ELSE 0 END) AS Ones
        FROM Reviews
        INNER JOIN Movies
        ON Movies.MovieID = Reviews.MovieID
        GROUP BY Movies.MovieID
    ) AS R
    RIGHT JOIN Movies
    ON Movies.MovieID = R.MovieID
    ORDER BY AvgRating DESC, Movies.MovieName ASC;
    ");

    // Get user input for the name of a movie to search for
    System.Console.Write("movie> ");
    input = System.Console.ReadLine();

    // Keep processing the input until the next input is empty
    while(input != ""){
      
      // SQL Query to get all the movies that contain the name that the user provided as input
      // Each row contains the movie name, total reviews, and the number of reviews for each rank 1-5
      sqlReviews = string.Format(@"
      SELECT 
          Movies.MovieName,
          Count(*) AS TotalReviews,
          Sum(CASE WHEN Reviews.Rating = '5' THEN 1 ELSE 0 END) AS Fives,
          Sum(CASE WHEN Reviews.Rating = '4' THEN 1 ELSE 0 END) AS Fours,
          Sum(CASE WHEN Reviews.Rating = '3' THEN 1 ELSE 0 END) AS Threes,
          Sum(CASE WHEN Reviews.Rating = '2' THEN 1 ELSE 0 END) AS Twos,
          Sum(CASE WHEN Reviews.Rating = '1' THEN 1 ELSE 0 END) AS Ones
      FROM Reviews
      RIGHT JOIN Movies
      ON Movies.MovieID = Reviews.MovieID
      WHERE Movies.MovieName LIKE '%{0}%'
      GROUP BY Movies.MovieName
      ORDER BY Movies.MovieName ASC;
      ", input.Replace("'", "''")); // Replace each " ' " with " '' "

      try{
        // Try to establish a connection with the database
        db = new SqlConnection(connectionInfo);
        db.Open();

        cmd.Connection = db;
        adapter = new SqlDataAdapter(cmd);

        // Processes the query for the reviews        
        processQuery(ref reviewsDS, ref cmd, sqlReviews, ref adapter, ref reviewRows, ref numReviewRows);

        // Processes the query for the ranks
        processQuery(ref ranksDS, ref cmd, sqlRank, ref adapter, ref rankRows, ref numRankRows);

        // Check if the review table which contains the movies with matching input is empty
        if(numReviewRows == 0){
          System.Console.WriteLine("**none found");
        }else{ // Movie(s) found
          // Go through each row in the table
          foreach (DataRow row in reviewRows){
            // Extract the information
            movieName = System.Convert.ToString(row["MovieName"]);
            totalReviews = System.Convert.ToInt32(row["TotalReviews"]);
            bool noReviews = false; // Check if the movie has no reviews
            for(int i = 0; i < numRankRows; i++){
              if(movieName == System.Convert.ToString(rankRows[i]["MovieName"])){
                movieYear = System.Convert.ToString(rankRows[i]["MovieYear"]);
                if(rankRows[i]["AvgRating"] == System.DBNull.Value) // Check if the movie has DBNull for their average (no reviews)
                  noReviews = true;
                else
                  avgRating = System.Convert.ToDouble(rankRows[i]["AvgRating"]);
                rank = i+1;
              }
            }

            if(noReviews){ // Check if the movie found has no reviews
              System.Console.WriteLine("'{0}', released {1}\n Avg rating: <<no reviews>>\n Ranked {2} out of {3}",
              movieName,
              movieYear,
              rank,
              numRankRows
              );
            }else{ // Print the information for that given movie in the row
              System.Console.WriteLine("'{0}', released {1}\n Avg rating: {2} across {3} reviews [5,4,3,2,1: {4},{5},{6},{7},{8}]\n Ranked {9} out of {10}",
              movieName,
              movieYear,
              avgRating,
              totalReviews,
              System.Convert.ToInt32(row["Fives"]),
              System.Convert.ToInt32(row["Fours"]),
              System.Convert.ToInt32(row["Threes"]),
              System.Convert.ToInt32(row["Twos"]),
              System.Convert.ToInt32(row["Ones"]),
              rank,
              numRankRows
              );
            }
          }
        }


      } catch(Exception ex){ // Handle any errors that can be caused by the database or logical errors
        System.Console.WriteLine("**Error: {0}", ex.Message);
      } finally{ // Close the database regardless of the outcome 
        db.Close();
      }

      // Ask for user input once again
      System.Console.Write("movie> ");
      input = System.Console.ReadLine();

    }
      
    }//Main

    // Helper method that processes the given query by filling a set of parameters that are
    // passed by reference.
    // This sets the data set, rows of the first table, and the number of rows in that table
    private static void processQuery(ref DataSet set, ref SqlCommand cmd, string query, ref SqlDataAdapter adapter, ref DataRowCollection table, ref int numRows){
      // Clear the data set due to previous queries
      set.Clear();
      cmd.CommandText = query;
      adapter.Fill(set); // Fills the dataset with the db tables retrieved
      table = set.Tables[0].Rows; // Get all the rows in the first table
      numRows = table.Count;
    }
    
  }//class
}//namespace
