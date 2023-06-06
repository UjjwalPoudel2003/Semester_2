create table Book_Catalog
(
Book_Code number generated always as identity,
Book_Title varchar2(30),
Publisher_Name varchar2(20),
Category_Name varchar2(15),
Year_Of_Release number,
Total_Copies number,
Price number
);

insert into book_catalog(book_title, publisher_name, category_name, year_of_release, total_copies, price) values
("ujjwal the lone wanderer", "ujjwal", "adventure", 2020, 12, 1345);
insert into book_catalog(book_title, publisher_name, category_name, year_of_release, total_copies, price) values("ujjwal the lone warrior", "peterson henry", "adventure", 2019, 16, 1200);
insert into book_catalog(book_title, publisher_name, category_name, year_of_release, total_copies, price) values("ujjwal the freedom fighter", "subtres eww", "motivation", 2022, 15, 2465);
insert into book_catalog(book_title, publisher_name, category_name, year_of_release, total_copies, price) values("Ujjwal the auto-biography", "ujjwal", "literature", 2019, 54, 813);
insert into book_catalog(book_title, publisher_name, category_name, year_of_release, total_copies, price) values("How ujjwal ruled the world", "sam suburbs", "motivation", 2023, 243, 1456);

commit;