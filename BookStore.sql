USE master
GO
IF EXISTS(select * from sys.databases where name='ql_sach')
DROP DATABASE ql_sach;

GO
create DATABASE  ql_sach;

GO
USE ql_sach;

GO
--đại lý
CREATE TABLE agency
(
  agency_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  agency_name nVARCHAR(100) NOT NULL ,
  agency_address nVARCHAR(100) NOT NULL ,
  agency_phone VARCHAR(12),
);
--nxb
CREATE TABLE supplier
(
  supplier_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  supplier_name nVARCHAR(100) NOT NULL ,
  supplier_address nVARCHAR(100) NOT NULL ,
  supplier_phone VARCHAR(12),
);
-- book
CREATE TABLE book
(
  book_id  int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  book_name nVARCHAR(100) NOT NULL ,
  fk_supplier int NOT NULL,
  book_stock int,
  book_seling_price DECIMAL(14),
  book_purchase_price DECIMAL(14),
  FOREIGN KEY(fk_supplier) REFERENCES supplier(supplier_id)
);

--kho
CREATE TABLE store
(
	store_id int identity(1,1) not null primary key,
	fk_book int not null,
	store_quantity int,
	store_seling_price decimal(14),
	store_purchase_price decimal(14),
	store_time datetime,
	foreign key (fk_book) references book(book_id)
)
-- sale_order phieu xuat
CREATE TABLE sale_order
(
  sale_order_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  fk_agency int NOT NULL ,
  sale_order_created_at datetime ,
  sale_order_total_money decimal(14),
  sale_order_status nVARCHAR(10),
  FOREIGN KEY (fk_agency) REFERENCES agency (agency_id)
);

CREATE TABLE sale_order_item
(
  sale_order_item_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  fk_sale_order int NOT NULL,
  fk_book INT NOT NULL ,
  sale_order_item_price DECIMAL(14),
  sale_order_item_quantity INT,
  sale_order_money decimal(14),
  FOREIGN KEY (fk_sale_order) REFERENCES sale_order (sale_order_id),
  FOREIGN KEY (fk_book) REFERENCES book (book_id)
)

-- purchase_order phieu nhap


CREATE TABLE purchase_order
(
  purchase_order_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  fk_supplier int  NOT NULL ,
  purchase_order_created_at datetime ,
  purchase_order_total_money decimal(14),
  purchase_order_status nVARCHAR(10),
  FOREIGN KEY (fk_supplier) REFERENCES supplier (supplier_id)
);
CREATE TABLE purchase_order_item
(
  purchase_order_item_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  fk_purchase_order int NOT NULL,
  fk_book INT NOT NULL ,
  purchase_order_item_price DECIMAL(14),
  purchase_order_item_quantity INT,
  purchase_order_money decimal(14),
  FOREIGN KEY  (fk_purchase_order) REFERENCES purchase_order (purchase_order_id),
  FOREIGN KEY  (fk_book) REFERENCES book (book_id)
);
--thanh toan phieu xuat
CREATE TABLE sale_payment
(
	sale_payment_id int identity(1,1) NOT NULL PRIMARY KEY,
	fk_sale_order int not null,
	sale_payment_money_pay decimal(14),
	sale_payment_debt decimal(14), --nợ
	sale_payment_time datetime,
	foreign key(fk_sale_order) references sale_order(sale_order_id)
)
--chi tiet thanh toan phieu xuat
CREATE TABLE sale_payment_item
(
	sale_payment_item_id int identity(1,1) not null primary key,
	fk_sale_payment int not null,
	fk_book int not null,
	sale_payment_item_quantity int,
	sale_payment_item_price decimal(14),
	sale_payment_item_money decimal(14),
	foreign key(fk_sale_payment) references sale_payment(sale_payment_id),
	foreign key(fk_book) references book(book_id)
)
--thanh toan phieu nhap
CREATE TABLE purchase_payment
(
	purchase_payment_id int identity(1,1) primary key  not null,
	fk_purchase_order int not null,
	purchase_payment_money_pay decimal(14),
	purchase_payment_debt decimal(14),
	purchase_payment_time datetime,
	foreign key (fk_purchase_order) references purchase_order(purchase_order_id)
)
--chi tiet thanh toan phieu nhap
CREATE TABLE purchase_payment_item
(
	purchase_payment_item_id int identity(1,1) not null primary key,
	fk_purchase_payment int not null,
	fk_book int not null,
	purchase_payment_item_quantity int,
	purchase_payment_item_price decimal(14),
	purchase_payment_item_money decimal(14),
	foreign key(fk_purchase_payment) references purchase_payment(purchase_payment_id),
	foreign key(fk_book) references book(book_id)
)
--nợ công đại lý
CREATE TABLE agency_debt
(
	agency_debt_id int identity(1,1) not null primary key,
	fk_agency int not null,
	fk_sale_payment int not null,
	agency_debt_total_money decimal(14), --tong tien nợ
	agency_debt_time datetime,
	foreign key (fk_agency) references agency(agency_id),
	foreign key (fk_sale_payment) references sale_payment(sale_payment_id)
)
--chi tiết nợ công đại lý
CREATE TABLE agency_debt_item
(
	agency_debt_item_id int identity(1,1) not null primary key,
	fk_agency_debt int not null,
	fk_book int not null,
	agency_debt_item_quantity int,
	agency_debt_item_money decimal(14),
	foreign key (fk_agency_debt) references agency_debt(agency_debt_id),
	foreign key (fk_book) references book(book_id)
)

--nợ công nhà xuất bản
CREATE TABLE supplier_debt
(
	supplier_debt_id int identity(1,1) not null primary key,
	fk_supplier int not null,
	fk_purchase_payment int not null,
	supplier_debt_total_money decimal(14), --tong tien nợ
	supplier_debt_time datetime,
	foreign key (fk_supplier) references supplier(supplier_id),
	foreign key (fk_purchase_payment) references purchase_payment(purchase_payment_id)
)

--chi tiết nợ công nxb
CREATE TABLE supplier_debt_item
(
	supplier_debt_item_id int identity(1,1) not null primary key,
	fk_supplier_debt int not null,
	fk_book int not null,
	supplier_debt_item_quantity int,
	supplier_debt_item_money decimal(14),
	foreign key (fk_supplier_debt) references supplier_debt(supplier_debt_id),
	foreign key (fk_book) references book(book_id)
)

insert into agency(agency_name,agency_address,agency_phone) values('Kim Dong','24 Hoang Van Thu','19001567');
insert into sale_order(fk_agency,sale_order_total_money,sale_order_created_at,sale_order_status) values(1,100000,GETDATE(),N'tét');
insert into sale_order_item(fk_sale_order,fk_book)
	values(1,2);
insert into supplier(supplier_name,supplier_address) values('Hai Ba Trung','24 Thai Ha');
insert into book(book_name,fk_supplier) values('tieng anh',1);
insert into book(book_name,fk_supplier) values('tieng em',1);