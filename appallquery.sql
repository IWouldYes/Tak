
create table [user](
[id] int identity(1,1) constraint PK_user primary key
,[login] varchar(30) not null
,[password] varchar(30) not null
,[first_name] varchar(MAX) NOT null
,[last_name] varchar(MAX) NOT null
,[phone_number] int
,[description] varchar(500)
,[country] varchar(max) NOT null
,[city] varchar(max) NOT null
,[street] varchar(max) NOT null
);

create table [images](
[id] int identity(1,1) constraint PK_images primary key
,[image] image not null
);

create table [categories](
[category_id] int identity(1,1) constraint PK_categories primary key
,[category_name] varchar(30) not null
);

create table [listings](
[id] int identity(1,1) constraint PK_listings primary key
,[user_id] int NOT null constraint FK_listings_user_id references [user](id) on delete cascade
,[mainimage_id] int null constraint FK_listings_Mainimage_id references [images](id) on delete SET null
,[secondaryimage_id] int null constraint FK_listings_Secondaryimage_id references [images](id) on delete no action
,[price] float null
,[title] varchar(50) not null
,[description] varchar(500) null
,[category_id] int not null constraint FK_listings_category_id references [categories](category_id) on delete cascade
,[quantity] int not null
,[views] int not null
);

create table [likes](
[user_id] int not null constraint FK_Likes_user_id references [user](id) on delete cascade
,[listing_id] int not null constraint FK_Likes_Listing_id references [listings](id) on delete no action
, constraint PK_Likes primary key (user_id, listing_id)
);

create table [messages](
[id] int identity(1,1) constraint PK_messages primary key
,[sender_id] int not null constraint FK_messages_sender_id references [user](id) on delete cascade
,[recipient_id] int not null constraint FK_messages_recipient_id references [user](id) on delete no action
,[message_content] varchar(300)
,[listing_id] int constraint FK_messages_listing_id references [listings](id) on delete no action
);

create table [comments](
[id] int identity(1,1) constraint PK_comments primary key
,[user_id] int not null constraint FK_comments_user_id references [user](id) on delete cascade
,[listing_id] int not null constraint FK_comments_Listing_id references [listings](id) on delete no action
,[content] varchar(300) not null
);

create table [reviews](
[id] int identity(1,1) constraint PK_reviews primary key
,[reviewer_id] int not null constraint FK_reviews_reviewer_id references [user](id) on delete cascade
,[reviewee_id] int not null constraint FK_reviews_reviewee_id references [user](id) on delete no action
,[content] varchar(300) not null
);

create table [ratings](
[id] int identity(1,1) constraint PK_ratings primary key
,[rater_id] int not null constraint FK_ratings_rater_id references [user](id) on delete no action
,[ratee_id] int not null constraint FK_ratings_ratee_id references [user](id) on delete no action
,[rating_value] int  not null
);
