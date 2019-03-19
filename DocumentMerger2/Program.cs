using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        // Make a new method here that checks doc names from args

        static int WriteDocument(StreamWriter writer, string file)
        {
            StreamReader reader = null;
            int count = 0;

            try
            {
                reader = new StreamReader(file);
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    count += line.Length;
                    writer.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing {file} to new file: {ex.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return count;
        }

        static void Main(string[] args) // Change args length with args.Length? 
        {
            do
            {
                // Need to replace instances of 'fileName' and other vars to 
                // command line args instead. Replace all further commented vars:
                StreamWriter writer = null;

                try
                {
                    writer = new StreamWriter(/* fileName */); // Probably need to assign args to vars
                    int count = WriteDocument(writer,/* d1 */);
                    count += WriteDocument(writer, /* d2 */);
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters", /* fileName */);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to {/* fileName */}: {ex.Message}");
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }

                Console.Write("\nWould you like to merge two more documents? (y/n): ");
            }
            while (Console.ReadLine().ToLower() == "y");
        }
    }
}
