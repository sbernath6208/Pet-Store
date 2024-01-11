/****** Drop Tables which allows for them to be recreated ******/
drop table order_line;
drop table orders;
drop table profile;
drop table pet_keyword;
drop table pet;
drop table address;
drop table state;
drop table shipper;
drop table keyword;
drop table category;
drop table status;
drop table breed;

/****** Create Table breed ******/
CREATE TABLE [dbo].[breed](
	[breed_id] [int] IDENTITY(1,1) NOT NULL,
	[breed_desc] [varchar](50) NOT NULL
 CONSTRAINT [pk_breed] PRIMARY KEY CLUSTERED ( [breed_id] ASC )
);
/****** Create Table status ******/
CREATE TABLE [dbo].[status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_desc] [varchar](50) NOT NULL
 CONSTRAINT [pk_status] PRIMARY KEY CLUSTERED ( [status_Id] ASC )
);
/****** Create Table category ******/
CREATE TABLE [dbo].[category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_desc] [varchar](50) NOT NULL
 CONSTRAINT [pk_category] PRIMARY KEY CLUSTERED ( [category_id] ASC )
);
/****** Create Table keyword ******/
CREATE TABLE [dbo].[keyword](
	[keyword_id] [int] IDENTITY(1,1) NOT NULL,
	[keyword_desc] [varchar](50) NOT NULL
 CONSTRAINT [pk_keyword] PRIMARY KEY CLUSTERED ( [keyword_id] ASC )
);
/****** Create table shipper ******/
CREATE TABLE [dbo].[shipper](
	[shipper_id] [int] IDENTITY(1,1) NOT NULL,
	[shipping_desc] [varchar](50) NOT NULL,
	[shipping_flat_rate] [decimal] (6, 2) NOT NULL
 CONSTRAINT [pk_shipper] PRIMARY KEY CLUSTERED ( [shipper_id] ASC )
);
/****** Create table state ******/
CREATE TABLE [dbo].[state](
	[state_abbr] [varchar](2) NOT NULL,
	[state_name] [varchar](50) NOT NULL,
	[sales_tax] [decimal] (6, 2) NOT NULL
 CONSTRAINT [pk_state] PRIMARY KEY CLUSTERED ( [state_abbr] ASC )
);
/****** Create table pet ******/
CREATE TABLE [dbo].[pet](
	[pet_id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NOT NULL,
	[status_id] [int] NOT NULL,
	[breed_id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](2000) NOT NULL,
	[price] [decimal] (9, 2) NOT NULL,
	[image] [varbinary] (max)
 CONSTRAINT [pk_pet] PRIMARY KEY CLUSTERED ( [pet_id] ASC )
);
/****** Add FOREIGN KEY constraints ******/
ALTER TABLE [dbo].[pet]  WITH CHECK ADD CONSTRAINT [fk_pet_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([category_id]);
ALTER TABLE [dbo].[pet]  WITH CHECK ADD CONSTRAINT [fk_pet_breed] FOREIGN KEY([breed_id])
REFERENCES [dbo].[breed] ([breed_id]);
ALTER TABLE [dbo].[pet]  WITH CHECK ADD CONSTRAINT [fk_pet_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id]);

/****** Create table address ******/
CREATE TABLE [dbo].[address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address_line_1] [varchar](100) NOT NULL,
	[address_line_2] [varchar](100),
	[city] [varchar] (50) NOT NULL,
	[state_abbr] [varchar](2) NOT NULL,
	[postal_code] [varchar](10) NOT NULL
 CONSTRAINT [pk_address] PRIMARY KEY CLUSTERED ( [address_id] ASC )
);
/****** Add FOREIGN KEY constraints ******/
ALTER TABLE [dbo].[address]  WITH CHECK ADD CONSTRAINT [fk_address_state] FOREIGN KEY([state_abbr])
REFERENCES [dbo].[state] ([state_abbr]);
/****** Create table profile ******/
CREATE TABLE [dbo].[profile](
	[profile_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[status_id] [int] NOT NULL,
	[address_id] [int] NOT NULL,
	[email] [varchar] (255) NOT NULL,
	[phone] [varchar](20) NULL,
	[username] [varchar](10) NOT NULL,
	[password] [varchar](14) NOT NULL
 CONSTRAINT [pk_profile] PRIMARY KEY CLUSTERED ( [profile_id] ASC )
);
/****** Add FOREIGN KEY constraints ******/
ALTER TABLE [dbo].[profile]  WITH CHECK ADD CONSTRAINT [fk_profile_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id]);
ALTER TABLE [dbo].[profile]  WITH CHECK ADD CONSTRAINT [fk_profile_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id]);
/****** Create Unique Constraint ******/
ALTER TABLE [dbo].[profile] ADD CONSTRAINT [uq_profile_username] UNIQUE([username]);
/****** Create table orders ******/
CREATE TABLE [dbo].[orders](
	[order_no] [int] IDENTITY(1,1) NOT NULL,
	[status_id] [int] NOT NULL,
	[username] [varchar](10) NOT NULL,
	[billing_first_name] [varchar](50) NOT NULL,
	[billing_last_name] [varchar](50) NOT NULL,
	[credit_card_no] [varchar] (20) NOT NULL,
	[bill_address_id] [int] NOT NULL,
	[shipper_id] [int] NOT NULL,
	[ship_to_first_name] [varchar](50) NOT NULL,
	[ship_to_last_name] [varchar](50) NOT NULL,
	[ship_to_address_id] [int] NOT NULL,
	[sales_tax] [decimal] (6, 2) NOT NULL,
	[shipping_cost] [decimal] (6, 2) NOT NULL,
	[total_cost] [decimal] (9, 2) NOT NULL
 CONSTRAINT [pk_orders] PRIMARY KEY CLUSTERED ( [order_no] ASC )
);
/****** Add FOREIGN KEY constraints ******/
ALTER TABLE [dbo].[orders]  WITH CHECK ADD CONSTRAINT [fk_orders_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id]);
ALTER TABLE [dbo].[orders]  WITH CHECK ADD CONSTRAINT [fk_orders_bill_address] FOREIGN KEY([bill_address_id])
REFERENCES [dbo].[address] ([address_id]);
ALTER TABLE [dbo].[orders]  WITH CHECK ADD CONSTRAINT [fk_orders_ship_address] FOREIGN KEY([ship_to_address_id])
REFERENCES [dbo].[address] ([address_id]);
ALTER TABLE [dbo].[orders]  WITH CHECK ADD CONSTRAINT [fk_orders_profile] FOREIGN KEY([username])
REFERENCES [dbo].[profile] ([username]);

/****** Create table orders ******/
CREATE TABLE [dbo].[order_line](
	[order_no] [int] NOT NULL,
	[line_no] [int] NOT NULL,
	[status_id] [int] NOT NULL,
	[pet_id] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[ship_date] [date] NULL
 CONSTRAINT [pk_order_line] PRIMARY KEY NONCLUSTERED ( [order_no], [line_no])
);
ALTER TABLE [dbo].[order_line]  WITH CHECK ADD CONSTRAINT [fk_order_line_order] FOREIGN KEY([order_no])
REFERENCES [dbo].[orders] ([order_no]);
ALTER TABLE [dbo].[order_line]  WITH CHECK ADD CONSTRAINT [fk_order_line_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id]);
ALTER TABLE [dbo].[order_line]  WITH CHECK ADD CONSTRAINT [fk_order_line_pet] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pet] ([pet_id]);

/****** Create table pet_keyword ******/
CREATE TABLE [dbo].[pet_keyword](
	[pet_id] [int] IDENTITY(1,1) NOT NULL,
	[keyword_id] [int] NOT NULL
 CONSTRAINT [pk_pet_keyword] PRIMARY KEY NONCLUSTERED ( [pet_id], [keyword_id] ASC )
);
/****** Add FOREIGN KEY constraints ******/
ALTER TABLE [dbo].[pet_keyword]  WITH CHECK ADD CONSTRAINT [fk_pet_keyword_pet] FOREIGN KEY([pet_id])
REFERENCES [dbo].[pet] ([pet_id]);
ALTER TABLE [dbo].[pet_keyword]  WITH CHECK ADD CONSTRAINT [fk_pet_keyword_keyword] FOREIGN KEY([keyword_id])
REFERENCES [dbo].[keyword] ([keyword_id]);

/****** Insert State Information ******/
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('AL', 'Alabama', 0.04);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('AK', 'Alaska', 0);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('AZ', 'Arizona', 0.056);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('AR', 'Arkansas', 0.065);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('CA', 'California', 0.0725);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('CO', 'Colorado', 0.029);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('CT', 'Connecticut', 0.0635);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('DE', 'Delaware', 0);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('DC', 'District of Columbia', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('FL', 'Florida', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('GA', 'Georgia', 0.04);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('HI', 'Hawaii', 0.04);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('ID', 'Idaho', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('IL', 'Illinois', 0.0625);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('IN', 'Indiana', 0.07);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('IA', 'Iowa', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('KS', 'Kansas', 0.065);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('KY', 'Kentucky', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('LA', 'Louisiana', 0.0445);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('ME', 'Maine', 0.055);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MD', 'Maryland', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MA', 'Massachusetts', 0.0625);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MI', 'Michigan', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MN', 'Minnesota', 0.06875);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MS', 'Mississippi', 0.07);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MO', 'Missouri', 0.04225);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('MT', 'Montana', 0);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NE', 'Nebraska', 0.055);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NV', 'Nevada', 0.0685);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NH', 'New Hampshire', 0);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NJ', 'New Jersey', 0.06625);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NM', 'New Mexico', 0.05125);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NY', 'New York', 0.04);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('NC', 'North Carolina', 0.0475);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('ND', 'North Dakota', 0.05);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('OH', 'Ohio', 0.0575);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('OK', 'Oklahoma', 0.045);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('OR', 'Oregon', 0);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('PA', 'Pennsylvania', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('RI', 'Rhode Island', 0.07);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('SC', 'South Carolina', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('SD', 'South Dakota', 0.045);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('TN', 'Tennessee', 0.07);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('TX', 'Texas', 0.0625);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('UT', 'Utah', 0.061);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('VT', 'Vermont', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('VA', 'Virginia (b)', 0.053);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('WA', 'Washington', 0.065);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('WV', 'West Virginia', 0.06);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('WI', 'Wisconsin', 0.05);
INSERT INTO state(state_abbr, state_name, sales_tax)
        VALUES ('WY', 'Wyoming', 0.04);