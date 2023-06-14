using System;
using System.Collections.Generic;
using System.IO;

namespace Week6_FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestFileIO();
        }

        static void TestFileIO()
        {
            Library lib1 = new Library("L1_01_T203", "Under the tree");
            Console.WriteLine($"lib1 : {lib1}");

            //lib1.AddNewBook();
            //lib1.AddNewBook();

            lib1.ShowBooks();

            Library lib2 = new Library("L2_03_M203", "The Sacred Space");
            Console.WriteLine($"\n\nlib2 : {lib2}");
            //lib2.AddNewBook();
            //lib2.AddNewBook();
            lib2.ShowBooks();

            Library lib3 = new Library("L3_02_M203", "Over the Cloud");
            Console.WriteLine($"\nlib3 : {lib3}");
            //lib3.AddNewBook();
            lib3.ShowBooks();
        }

        public enum BookGenre
        {
            Fiction, NonFiction, Biography, Mythology
        }

        public class Book
        {
            public string Title { get; }
            public string Author { get; }
            public BookGenre Genre { get; }

            public Book(string title, string author, BookGenre genre)
            {
                this.Title = title;
                this.Author = author;
                this.Genre = genre;
            }

            public override string ToString()
            {
                return $"Book title: {this.Title} ----- Author : {this.Author} ----- Genre : {this.Genre}";
            }
        }

        public class Library
        {
            private const string FILE_NAME = "library_data.txt";
            private string LibraryID { get; }
            public string LibraryName { get; }

            //library has books
            //book list

            //public Book mybook;

            //class relationaship - HAS - A
            // one class has a(n) object(s) of another class
            public List<Book> bookList;
            //public Employee librarian;

            public Library(string ID, string name)
            {
                this.LibraryID = ID;
                this.LibraryName = name;
                this.bookList = new List<Book>();
                //this.librarian = new Employee();

                //read all the books from this library from the file and save in the book list
                using(StreamReader reader = new StreamReader(FILE_NAME))
                {
                    //reader.ReadLine(); 
                    //will read one line at a time from specified file
                    //returns a string containing entre line
                    //returns null if there is no (more) line to process

                    string dataLine;
                    while((dataLine = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"dataLine : {dataLine}");


                        //extract seperate values from dataLine - csv
                        string[] values = dataLine.Split(',');

                        Console.WriteLine($"values[0] : {values[0]}\n values[1] : {values[1]}\n values[2] : {values[2]}\n values[1] : {values[3]}\n");

                        //check if the book is for this library object
                        if (values[0] == this.LibraryID)
                        {
                            //create a book object using the values
                            string title = values[1];
                            string author = values[2];

                            //to get the numeric value of enum
                            //int age = Convert.ToInt32(values[3]);

                            BookGenre genre = (BookGenre)Enum.Parse(typeof(BookGenre), values[3]);

                            Book newBook = new Book(title, author, genre);

                            //Book newBook = new Book(values[1], values[2], (BookGenre)Enum.Parse(typeof(BookGenre), values[3]));

                            //add the object to the book list
                            this.bookList.Add(newBook);
                        }
                    }

                    //close the reader instance
                    reader.Close();
                }
            }

            public void AddNewBook()
            {
                Console.Write("Please enter book title : ");
                string title = Console.ReadLine();

                Console.Write("Please enter book author : ");
                string author = Console.ReadLine();

                Console.Write("Please choose book genre [0: Fiction, 1: NonFiction, 2: Biography, 3: Mythology] : ");
                int genre = Convert.ToInt16(Console.ReadLine());

                if (genre < 0 || genre > 4)
                {
                    genre = 0;
                }
                BookGenre selectedGenre = (BookGenre)genre;
                Book newBook = new Book(title, author, selectedGenre);

                Console.WriteLine($"New book added : {newBook}");

                //add book object to book list
                this.bookList.Add(newBook);

                //save the book permanently in the text file
                //Comma Seperated Values (CSV)

                //FILE_NAME - must have .txt extension
                //use only name of the file such as LibraryData.txt
                //do not use hard-coded path such as D:/LibraryData.txt
                //the default location of the file is in ProjectFolder/bin/Debug

                StreamWriter writer = new StreamWriter(FILE_NAME, append: true);

                //write the book information to the file in csv format
                string dataLine = $"{this.LibraryID},{newBook.Title},{newBook.Author},{newBook.Genre}";
                //WriteLine() - writes a string data to the file and add new line (\n) at the end
                //so that next record will be added in separate line
                writer.WriteLine(dataLine);

                //close the writer instance
                writer.Close();
            }

            public void ShowBooks()
            {
                Console.WriteLine($"\nShowing books from library {this.LibraryID}");
                foreach (Book book in this.bookList)
                {
                    Console.WriteLine(book);
                }

            }

            public override string ToString()
            {
                return $"Library ID : {this.LibraryID} ---- Library Name : {this.LibraryName}";
            }
        }
    }
}
