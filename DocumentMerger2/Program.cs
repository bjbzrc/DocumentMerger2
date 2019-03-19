using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static string DocumentStart()
        {
            Console.Write("Enter name of document: ");

            string doc;
            while ((doc = Console.ReadLine()).Length == 0 || !File.Exists(doc))
            {
                Console.Write("Document not found, please enter a valid document name: ");
            }

            return doc;
        }

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

        static void Main(string[] args)
        {
            Console.WriteLine("Document Merger\n");

            do
            {
                string d1 = DocumentStart();
                string d2 = DocumentStart();
                string fileName = d1.Substring(0, d1.Length - 4) + d2;
                StreamWriter writer = null;

                try
                {
                    writer = new StreamWriter(fileName);
                    int count = WriteDocument(writer, d1);
                    count += WriteDocument(writer, d2);
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters", fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to {fileName}: {ex.Message}");
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
