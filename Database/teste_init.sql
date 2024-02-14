USE mdp;

# Tipos Básicos
INSERT INTO ageratings(name) VALUES("E - Everyone"),("T - Teen"),("A - Adult only");
INSERT INTO categories(name) VALUES("Isekai"),("Slice of Life"),("Ecchi");
INSERT INTO countries(name, code) VALUES("Japan","JPN"),("United States","USA"),("South Korea","KOR");
INSERT INTO demographics(name) VALUES("Egirls"),("Incels"),("Programmers");
INSERT INTO imagetypes(name) VALUES("Card"),("Main"),("Other");
INSERT INTO medias(name) VALUES("Anime"),("Manga"),("Novel");
INSERT INTO roles (name) VALUES("Voice actor"),("Publisher"),("Studio");
# Persons
INSERT INTO persons (shortName, fullName, country, description, birthday, gender,nicknames) 
VALUES ('Takahashi Rie', 'Takahashi Rie', 1, 'Sweetest voice in Japan. In the world, actually. I fucking love her.', '1994-02-27', 'F',"Rieri,Rie-chan");

INSERT INTO persons (shortName, fullName, country, description, birthday, gender) 
VALUES ('Alice', 'Alice Smith', 2, 'Consectetur adipiscing elit', '1985-12-28', 'F');

INSERT INTO persons (shortName, fullName, country, description, birthday, gender) 
VALUES ('Bob', 'Bob Johnson', 3, 'Sed do eiusmod tempor incididunt', '1978-08-03', 'M');

INSERT INTO persons (shortName, fullName, country, description, birthday, gender) 
VALUES ('Emma', 'Emma Brown', 2, 'Ut labore et dolore magna aliqua', '1995-02-20', 'F');

INSERT INTO persons (shortName, fullName, country, description, birthday, gender) 
VALUES ('David', 'David Wilson', 1, 'Ut enim ad minim veniam', '1983-07-10', 'M');

INSERT INTO persons (shortName, fullName, country, description, birthday, gender) 
VALUES ('Sophia', 'Sophia Lee', 3, 'Quis nostrud exercitation ullamco', '1992-11-18', 'F');

# Works
INSERT INTO works (shortName, fullName, media, description, ageRating, mainParticipantRole, mainParticipant, releaseDate) 
VALUES 
('Re:zero', 'Re:zero kara hajimeru isekai seikatsu', 1, 'Guy gets kidnapped to another world, dies many times for elf girl and her egirl servant', 1, 3, 'White Fox', '2016-04-04'),
('Work2', 'Work Two', 2, 'Consectetur adipiscing elit', 2, 2, 'Actor2', '2023-02-02'),
('Work3', 'Work Three', 3, 'Sed do eiusmod tempor incididunt', 3, 3, 'Actor3', '2023-03-03'),
('Work4', 'Work Four', 1, 'Ut labore et dolore magna aliqua', 1, 1, 'Actor1', '2023-04-04'),
('Work5', 'Work Five', 2, 'Ut enim ad minim veniam', 2, 2, 'Actor2', '2023-05-05'),
('Work6', 'Work Six', 3, 'Quis nostrud exercitation ullamco', 3, 3, 'Actor3', '2023-06-06'),
('Work7', 'Work Seven', 1, 'Duis aute irure dolor in reprehenderit', 1, 1, 'Actor1', '2023-07-07'),
('Work8', 'Work Eight', 2, 'Excepteur sint occaecat cupidatat non proident', 2, 2, 'Actor2', '2023-08-08'),
('Work9', 'Work Nine', 3, 'Sunt in culpa qui officia deserunt mollit anim id est laborum', 3, 3, 'Actor3', '2023-09-09'),
('Work10', 'Work Ten', 1, 'Lorem ipsum dolor sit amet', 1, 1, 'Actor1', '2023-10-10'),
('Work11', 'Work Eleven', 2, 'Consectetur adipiscing elit', 2, 2, 'Actor2', '2023-11-11'),
('Work12', 'Work Twelve', 3, 'Sed do eiusmod tempor incididunt', 3, 3, 'Actor3', '2023-12-12'),
('Work13', 'Work Thirteen', 1, 'Ut labore et dolore magna aliqua', 1, 1, 'Actor1', '2024-01-01'),
('Work14', 'Work Fourteen', 2, 'Ut enim ad minim veniam', 2, 2, 'Actor2', '2024-02-02'),
('Work15', 'Work Fifteen', 3, 'Quis nostrud exercitation ullamco', 3, 3, 'Actor3', '2024-03-03'),
('Work16', 'Work Sixteen', 1, 'Duis aute irure dolor in reprehenderit', 1, 1, 'Actor1', '2024-04-04'),
('Work17', 'Work Seventeen', 2, 'Excepteur sint occaecat cupidatat non proident', 2, 2, 'Actor2', '2024-05-05'),
('Work18', 'Work Eighteen', 3, 'Sunt in culpa qui officia deserunt mollit anim id est laborum', 3, 3, 'Actor3', '2024-06-06'),
('Work19', 'Work Nineteen', 1, 'Lorem ipsum dolor sit amet', 1, 1, 'Actor1', '2024-07-07'),
('Work20', 'Work Twenty', 2, 'Consectetur adipiscing elit', 2, 2, 'Actor2', '2024-08-08');

# Users
INSERT INTO users (nickname, country, description, birthday, gender, email, password) 
VALUES 
('Onani', 1, 'Just a regular guy', '1995-01-01', 'M', 'user@example.com', 'password'),
('user2', 2, 'Consectetur adipiscing elit', '1990-02-02', 'F', 'user2@example.com', 'password2'),
('user3', 3, 'Sed do eiusmod tempor incididunt', '1988-03-03', 'M', 'user3@example.com', 'password3'),
('user4', 1, 'Ut labore et dolore magna aliqua', '1985-04-04', 'F', 'user4@example.com', 'password4'),
('user5', 2, 'Ut enim ad minim veniam', '1982-05-05', 'M', 'user5@example.com', 'password5');

# Companies 
INSERT INTO companies (shortName, fullName, country, description, foundingDate) 
VALUES 
('White Fox', 'White Fox Co., Ltd.', 1, 'A good fucking studio', '2007-04-01'),
('company2', 'Company Two', 2, 'Consectetur adipiscing elit', '2001-02-02'),
('company3', 'Company Three', 3, 'Sed do eiusmod tempor incididunt', '2002-03-03'),
('company4', 'Company Four', 1, 'Ut labore et dolore magna aliqua', '2003-04-04'),
('company5', 'Company Five', 2, 'Ut enim ad minim veniam', '2004-05-05');

# Associados ao Work principal de teste
INSERT INTO workcategories(work,category) VALUES (1,1);
INSERT INTO workdemographics(work,demographics) VALUES (1,2),(1,3);
INSERT INTO workcompanyparticipations(work,company,role) VALUES (1,1,3),(1,2,2),(1,3,2),(1,4,2);
INSERT INTO workimages (work,type,url) VALUES (1,1,"assets/imgs/works/1card.png"),(1,2,"assets/imgs/works/1main.png");
INSERT INTO news (title,text) VALUES ("Season 3 Coming!","Believe if you want!"),("Another Rezero news","But i dont have crativity to describe it"),
("Another one","Because i thought three would look good");
INSERT INTO newsimages(news,type,url) VALUES (1,2,"assets/imgs/news/1.png"),(2,2,"assets/imgs/news/2.png"),(3,2,"assets/imgs/news/3.png");
INSERT INTO worknews (news, work) VALUES (1,1),(2,1),(3,1);
INSERT INTO workothernames (work,name)VALUES(1,"");
INSERT INTO workpersonparticipations (work,person,role)VALUES(1,1,1),(1,2,1),(1,3,1),(1,4,1),(1,5,1),(1,6,1);
INSERT INTO reviews (user,rating,comment,date) VALUES (1,10,"A great anime","2018-05-19"),(1,7,"A good anime","2020-05-19");
INSERT INTO workreviews (review,work) VALUES (1,1),(2,1);

# Associados à person principal de teste
INSERT INTO personimages (person,type,url) VALUES (1,1,"assets/imgs/persons/1card.png"),(1,2,"assets/imgs/persons/1main.png");
INSERT INTO personroles (person,role) VALUES (1,1);

# Associados à company principal de teste
INSERT INTO companyimages (company,type,url) VALUES (1,1,"assets/imgs/companies/1card.png"),(1,2,"assets/imgs/companies/1main.png");
INSERT INTO companyaffiliations (company,person,start) VALUES (1,1,"2020-01-01"),(1,2,"2020-01-01"),(1,3,"2020-01-01"),(1,4,"2020-01-01"),(1,5,"2020-01-01");

# Global News 
INSERT INTO news (title,text) VALUES ("Carousel test 1!","Believe if you want!"),("Carousel test 2","But i dont have crativity to describe it"),
("Carousel test 3","Because i thought three would look good");
INSERT INTO newsimages(news,type,url) VALUES (4,2,"assets/imgs/news/4.png"),(5,2,"assets/imgs/news/5.png"),(6,2,"assets/imgs/news/6.png");
INSERT INTO globalnews (news) VALUES (4),(5),(6);
