/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     15/02/2015 15:26:24                          */
/*==============================================================*/

CONNECT / AS SYSDBA;
CREATE  USER MMABOOKS IDENTIFIED BY  MMABOOKS;
GRANT CONNECT, RESOURCE, UNLIMITED TABLESPACE TO  MMABOOKS;
GRANT CREATE VIEW TO  MMABOOKS;
DISCONNECT;
CONNECT  MMABOOKS/ MMABOOKS;

-- Type package declaration

/*==============================================================*/
/* Table: Customers                                           */
/*==============================================================*/
create table Customers 
(
   CustomerID         NUMBER(6)            not null,
   Name               VARCHAR2(100)        not null,
   Address            VARCHAR2(50)         not null,
   City               VARCHAR2(20)         not null,
   State              CHAR(2)              not null,
   ZipCode            CHAR(15)             not null,
   constraint PK_Customers primary key (CustomerID)
);


CREATE TABLE Employees(
	EmployeeID numeric(9, 0) NOT NULL PRIMARY KEY,
	LastName varchar(20) NOT NULL,
	FirstName varchar(10) NOT NULL,
	Title varchar(30),
	HireDate date,
	PostalCode varchar(10) 
	);
	
	
/*==============================================================*/
/* Table: InvoiceLineItems                                    */
/*==============================================================*/
create table InvoiceLineItems 
(
   InvoiceID          INTEGER              not null,
   ProductCode        CHAR(10)             not null,
   UnitPrice          NUMBER(8,2)          not null,
   Quantity           INTEGER              not null,
   ItemTotal          NUMBER(8,2)          not null,
   constraint PK_InvoiceLineItems primary key (InvoiceID, ProductCode)
);
 
--InvoiceID,ProductCode,UnitPrice,Quantity,ItemTotal  


/*==============================================================*/
/* Table: Invoices                                            */
/*==============================================================*/
create table Invoices 
(
   InvoiceID          NUMBER(6)            not null,
   CustomerID         INTEGER              not null,
   InvoiceDate        DATE                 not null,
   ProductTotal       NUMBER(8,2)          not null,
   SalesTax           NUMBER(8,2)          not null,
   Shipping           NUMBER(8,2)          not null,
   InvoiceTotal       NUMBER(8,2)          not null,
   constraint PK_Invoices primary key (InvoiceID)
);

--InvoiceID,CustomerID,InvoiceDate,ProductTotal,SalesTax, Shipping, InvoiceTotal 

--insert into invoices(CustomerID,InvoiceDate,ProductTotal,SalesTax, Shipping, InvoiceTotal) values(26,'17/07/1991',12,2,1,200);
/*==============================================================*/
/* Table: OrderOptions                                        */
/*==============================================================*/
create table OrderOptions 
(
   SalesTaxRate       NUMBER(18,4)         not null,
   FirstBookShipCharge NUMBER(8,2)          not null,
   AdditionalBookShipCharge NUMBER(8,2)          not null
);


/*==============================================================*/
/* Table: Products                                            */
/*==============================================================*/
create table Products (ProductCode CHAR(10) not null,
Description VARCHAR(50)not null,
UnitPrice NUMBER(8,2) not null,
OnHandQuantity INTEGER default 0 not null,
constraint PK_Products primary key (ProductCode)
);


/*==============================================================*/
/* Table: States                                              */
/*==============================================================*/
create table States 
(
   StateCode          CHAR(2)              not null,
   StateName          VARCHAR2(20)         not null,
   constraint PK_States primary key (StateCode)
);

CREATE SEQUENCE IncrClientes
  MINVALUE 1
  INCREMENT BY 1 
  START WITH 1
  nomaxvalue
;

Create Trigger TriggerClientes
  before insert on Customers
  for each row
  begin
    Select IncrClientes.nextval into:new.CustomerID from dual;
  end;
/

CREATE SEQUENCE IncrEmpleados
  MINVALUE 1
  INCREMENT BY 1 
  START WITH 1
  nomaxvalue
;

Create Trigger TriggerEmpleados
  before insert on Employees
  for each row
  begin
    Select IncrEmpleados.nextval into:new.EmployeeID from dual;
  end;
/



/

alter table Customers
   add constraint FK_Customers_States foreign key (State)
      references States (StateCode)
/

alter table InvoiceLineItems
   add constraint FK_InvoiceLineItems_Invoices foreign key (InvoiceID)
      references Invoices (InvoiceID)
      on delete cascade
/

alter table InvoiceLineItems
   add constraint FK_InvoiceLineItems_Products foreign key (ProductCode)
      references Products (ProductCode)
/

alter table Invoices
   add constraint FK_Invoices_Customers foreign key (CustomerID)
      references Customers (CustomerID)
      on delete cascade
/



-- insert into Products values('A2C#','Murachs ASP.NET 2.0 Web Programming with C# 2005',52.5000,4637);
-- insert into  Employees(LastName,FirstName,Title,HireDate,PostalCode)values('CANDO','JULIO','INGENIERO','14/02/2015','610');
-- insert into  Employees(LastName,FirstName,Title,HireDate,PostalCode)values('FLORES','MARCELO','TECNOLOGO','15/02/2015','619');
--insert into InvoiceLineItems values(1,'A2VB',30.5,30,915);



----------------


--INSERTAR EN ESTADOS
INSERT INTO STATES VALUES('AK','Alaska');   
INSERT INTO STATES VALUES('AL','Alabama');  
INSERT INTO STATES VALUES('AR','Arkansas'); 
INSERT INTO STATES VALUES('AZ','Arizona');  
INSERT INTO STATES VALUES('CA','California'); 
INSERT INTO STATES VALUES('CO','Colorado'); 
INSERT INTO STATES VALUES('CT','Connecticut');
INSERT INTO STATES VALUES('DC','District of Columbia'); 
INSERT INTO STATES VALUES('DE','Delaware'); 
INSERT INTO STATES VALUES('FL','Florida');  
INSERT INTO STATES VALUES('GA','Georgia');  
INSERT INTO STATES VALUES('HI','Hawaii');   
INSERT INTO STATES VALUES('IA','Iowa'); 

INSERT INTO STATES VALUES('ID','Idaho');
INSERT INTO STATES VALUES('IL','Illinois'); 
INSERT INTO STATES VALUES('I ','Indiana');  
INSERT INTO STATES VALUES('KS','Kansas');   
INSERT INTO STATES VALUES('KY','Kentucky'); 
INSERT INTO STATES VALUES('LA','Lousiana'); 
INSERT INTO STATES VALUES('MA','Massachusetts');  
INSERT INTO STATES VALUES('MD','Maryland'); 
INSERT INTO STATES VALUES('ME','Maine');
INSERT INTO STATES VALUES('MI','Michiga');  
INSERT INTO STATES VALUES('M ','Minnesota');
INSERT INTO STATES VALUES('MO','Missouri'); 
INSERT INTO STATES VALUES('MS','Mississippi');

INSERT INTO STATES VALUES('MT','Montana');  
INSERT INTO STATES VALUES('NC','North Carolina'); 
INSERT INTO STATES VALUES('ND','North Dakota');   
INSERT INTO STATES VALUES('NE','Nebraska'); 
INSERT INTO STATES VALUES('NH','New Hampshire');  
INSERT INTO STATES VALUES('NJ','New Jersey'); 
INSERT INTO STATES VALUES('NM','New Mexico'); 
INSERT INTO STATES VALUES('NV','Nevada');   
INSERT INTO STATES VALUES('NY','New York'); 
INSERT INTO STATES VALUES('OH','Ohio'); 
INSERT INTO STATES VALUES('OK','Oklahoma'); 
INSERT INTO STATES VALUES('OR','Orego');
INSERT INTO STATES VALUES('PA','Pennsylvania');   

INSERT INTO STATES VALUES('PR','Puerto Rico');
INSERT INTO STATES VALUES('qq','fsfsf');
INSERT INTO STATES VALUES('RI','Rhode Island');   
INSERT INTO STATES VALUES('SC','South Carolina'); 
INSERT INTO STATES VALUES('SD','South Dakota');   
INSERT INTO STATES VALUES('T ','Tennessee');
INSERT INTO STATES VALUES('TX','Texas');
INSERT INTO STATES VALUES('UT','Utah'); 
INSERT INTO STATES VALUES('VA','Virginia'); 
INSERT INTO STATES VALUES('VI','Virgin Islands'); 
INSERT INTO STATES VALUES('VT','Vermont');  
INSERT INTO STATES VALUES('WA','Washingto');
INSERT INTO STATES VALUES('WI','Wisconsi'); 

INSERT INTO STATES VALUES('WV','West Virginia');  
INSERT INTO STATES VALUES('XE','Oracle10g');  

-- INSERTAR EN PRODUCTOS

INSERT INTO PRODUCTS VALUES('A2C#','Murachs ASP.NET 2.0 Web Programming with C# 2005',52.5,4637); 
INSERT INTO PRODUCTS VALUES('A2VB','Murachs ASP.NET 2.0 Web Programming with VB 2005',52.5,3972);
INSERT INTO PRODUCTS VALUES('ADV2','Murachs ADO.NET 2.0 Database Programming VB 2005',52.5,4538);   
INSERT INTO PRODUCTS VALUES('CRFC','Murachs CICS Desk Reference',50,1865); 
INSERT INTO PRODUCTS VALUES('DB1R','DB2 for the COBOL Programmer, Part 1 (2nd Edition)',42,4820);  
INSERT INTO PRODUCTS VALUES('DB2R','DB2 for the COBOL Programmer, Part 2 (2nd Edition)',45,619);   
INSERT INTO PRODUCTS VALUES('JSE6','Murachs JAVA SE 6',52.5,3455); 
INSERT INTO PRODUCTS VALUES('MC#5','Murachs C# 2005',52.5,5136);   
INSERT INTO PRODUCTS VALUES('MCBL','Murachs Structured COBOL',62.5,2386);
INSERT INTO PRODUCTS VALUES('MCCP','Murachs CICS for the COBOL Programmer',54,2368);   
INSERT INTO PRODUCTS VALUES('MJSP','Murachs JAVA Servlets and JSP',49.5,4999);
INSERT INTO PRODUCTS VALUES('MVB5','Murachs Visual Basic 2005',52.5,2193);  
INSERT INTO PRODUCTS VALUES('SQL5','Murachs SQL Server 2005',52.5,2465); 
INSERT INTO PRODUCTS VALUES('ZJLR','Murach OS/390 and z/os JCL',300,677); 
INSERT INTO PRODUCTS VALUES('my  ','MYSQL',20,400); 
INSERT INTO PRODUCTS VALUES('ora ','Oracle 11g',300,200); 
INSERT INTO PRODUCTS VALUES('PST ','postgreSQL',123,89);
INSERT INTO PRODUCTS VALUES('Frb ','jj',30,21);   
INSERT INTO PRODUCTS VALUES('Po1 ','Firebird 2',120.4,200);   
INSERT INTO PRODUCTS VALUES('xxxxxxxxxx','hh',78.4,95); 
INSERT INTO PRODUCTS VALUES('JH  ','9898KJ',130.9,787); 
INSERT INTO PRODUCTS VALUES('hhhhhhhhhh','hh',78.01,100); 
INSERT INTO PRODUCTS VALUES('jfjdfjfjhf','MYSQL',1661,0); 

---INSERTAR EN FACTURA

-- INSERT INTO INVOICES VALUES(1,20,'15/02/2015',160,12,6.25,178.25);  
-- INSERT INTO INVOICES VALUES(2,694,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(3,35,'15/02/2015',45,3.38,3.75,52.13);  
-- INSERT INTO INVOICES VALUES(4,11,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(5,12,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(6,13,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(7,15,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(8,11,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(9,40,'15/02/2015',115,8.63,5,128.63);   
-- INSERT INTO INVOICES VALUES(10,33,'15/02/2015',177.5,13.31,6.25,197.06);  
-- INSERT INTO INVOICES VALUES(11,32,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(12,222,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(13,333,'15/02/2015',62.5,4.69,3.75,70.94);

-- INSERT INTO INVOICES VALUES(14,32,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(15,33,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(16,432,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(17,55,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(18,333,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(19,666,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(20,332,'15/02/2015',52.5,3.94,3.75,60.19);
-- INSERT INTO INVOICES VALUES(21,555,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(22,213,'15/02/2015',62.5,4.69,3.75,70.94);
-- INSERT INTO INVOICES VALUES(23,20,'15/02/2015',212.5,15.94,7.5,235.94);   
-- INSERT INTO INVOICES VALUES(24,10,'15/02/2015',242.5,18.19,8.75,269.44);  
-- INSERT INTO INVOICES VALUES(25,25,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(26,694,'15/02/2015',107.5,8.06,5,120.56); 

-- INSERT INTO INVOICES VALUES(27,20,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(28,88,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(29,10,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(30,50,'15/02/2015',625,46.88,15,686.88);
-- INSERT INTO INVOICES VALUES(31,15,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(32,15,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(33,10,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(34,10,'15/02/2015',62.5,4.69,3.75,70.94); 
-- INSERT INTO INVOICES VALUES(35,11,'15/02/2015',45,3.38,3.75,52.13); 
-- INSERT INTO INVOICES VALUES(36,10,'15/02/2015',49.5,3.71,3.75,56.96); 
-- INSERT INTO INVOICES VALUES(37,408,'15/02/2015',157.5,11.81,6.25,175.56); 
-- INSERT INTO INVOICES VALUES(38,25,'15/02/2015',52.5,3.94,3.75,60.19); 
-- INSERT INTO INVOICES VALUES(39,239,'15/02/2015',102,7.65,5,114.65); 

-- INSERT INTO INVOICES VALUES(40,125,'15/02/2015',157.5,11.81,6.25,175.56); 
-- INSERT INTO INVOICES VALUES(41,495,'15/02/2015',49.5,3.71,3.75,56.96);
-- INSERT INTO INVOICES VALUES(42,470,'15/02/2015',105,7.88,5,117.88); 
-- INSERT INTO INVOICES VALUES(43,233,'15/02/2015',105,7.88,5,117.88); 
-- INSERT INTO INVOICES VALUES(44,495,'15/02/2015',105,7.88,5,117.88); 
-- INSERT INTO INVOICES VALUES(45,200,'15/02/2015',52.5,3.94,3.75,60.19);
-- INSERT INTO INVOICES VALUES(46,326,'15/02/2015',52.5,3.94,3.75,60.19);
-- INSERT INTO INVOICES VALUES(47,601,'15/02/2015',102,7.65,5,114.65); 
-- INSERT INTO INVOICES VALUES(48,523,'15/02/2015',52.5,3.94,3.75,60.19);
-- INSERT INTO INVOICES VALUES(61,27,'04/02/2015',23,7,78,90);   
-- INSERT INTO INVOICES VALUES(62,27,'19/02/2015',28,7,4,45);
-- INSERT INTO INVOICES VALUES(63,701,'19/02/2015',0,0,7,7); 
-- INSERT INTO INVOICES VALUES(64,27,'19/02/2015',24,12,2,300);  

-- INSERT INTO INVOICES VALUES(65,71,'19/02/2015',35,7,5,600);   
-- INSERT INTO INVOICES VALUES(66,26,'19/02/2015',616,77,8,700); 
-- INSERT INTO INVOICES VALUES(67,26,'19/02/2015',12,7,8,56);
-- INSERT INTO INVOICES VALUES(68,26,'19/02/2015',12,23,3,334);  
-- INSERT INTO INVOICES VALUES(69,26,'19/02/2015',12,3,4,56);
-- INSERT INTO INVOICES VALUES(70,26,'19/02/2015',23,23,2,256);  
-- INSERT INTO INVOICES VALUES(71,72,'19/02/2015',35,45,45,45);  
-- INSERT INTO INVOICES VALUES(72,26,'19/02/2015',67,78,56,78);  
-- INSERT INTO INVOICES VALUES(73,27,'19/02/2015',234,3,2,2);
-- INSERT INTO INVOICES VALUES(74,33,'19/02/2015',32,3.3,3.5,34.5);
-- INSERT INTO INVOICES VALUES(75,27,'19/02/2015',67,89,6,800);  
-- INSERT INTO INVOICES VALUES(76,27,'19/02/2015',65,87,89,67);  
-- INSERT INTO INVOICES VALUES(77,26,'19/02/2015',67,78,89,4);   

-- INSERT INTO INVOICES VALUES(78,27,'19/02/2015',45,23,2,200);  
-- INSERT INTO INVOICES VALUES(79,26,'19/02/2015',12,2,1,200);   
-- INSERT INTO INVOICES VALUES(80,26,'19/02/2015',12,2,1,200);   
-- INSERT INTO INVOICES VALUES(81,26,'19/02/2015',12,2,1,200);   
-- INSERT INTO INVOICES VALUES(82,26,'19/02/2015',12,2,1,200);   
-- INSERT INTO INVOICES VALUES(83,26,'19/02/2015',12,2,1,200);   
-- INSERT INTO INVOICES VALUES(84,27,'19/02/2015',76,23,2,200);  
-- INSERT INTO INVOICES VALUES(85,27,'19/02/2015',200,200,9,56); 
-- INSERT INTO INVOICES VALUES(87,398,'28/02/2015',200,2,3,230); 
-- INSERT INTO INVOICES VALUES(86,26,'17/07/1991',12,2,1,200);   
-- INSERT INTO INVOICES VALUES(52,138,'19/02/2015',23,23,2,234); 
-- INSERT INTO INVOICES VALUES(121,13,'18/03/2015',6,34.68,12,335.68); 
-- INSERT INTO INVOICES VALUES(101,25,'17/07/1991',12,2,1,200);  

-- INSERT INTO INVOICES VALUES(124,701,'18/03/2015',15,140.65,12,1324.75);   
-- INSERT INTO INVOICES VALUES(122,701,'18/03/2015',8,47.88,5,451.88); 
-- INSERT INTO INVOICES VALUES(123,701,'18/03/2015',14,0,5,710); 
-- INSERT INTO INVOICES VALUES(125,13,'19/03/2015',16,94,5,12.894);
-- INSERT INTO INVOICES VALUES(126,46,'19/03/2015',7,41.04,12,395.04); 
-- INSERT INTO INVOICES VALUES(127,724,'19/03/2015',5,28.14,12,274.64);  

--INSERTAR EN DETALLE FACTURA

-- INSERT INTO INVOICELINEITEMS VALUES(18,'DB1R',42,2,84); 
-- INSERT INTO INVOICELINEITEMS VALUES(18,'ora ',300,2,600); 
-- INSERT INTO INVOICELINEITEMS VALUES(18,'PST ',123,3,369); 
-- INSERT INTO INVOICELINEITEMS VALUES(23,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(26,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(27,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(28,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(29,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(30,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(31,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(32,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(32,'MVB5',52.5,1,52.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(33,'A2VB',62.5,1,62.5);   

-- INSERT INTO INVOICELINEITEMS VALUES(33,'CRFC',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(33,'MVB5',52.5,1,52.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(41,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(42,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(43,'JSE6',52.5,1,52.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(44,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(45,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(46,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(46,'DB2R',45,1,45); 
-- INSERT INTO INVOICELINEITEMS VALUES(46,'MVB5',52.5,1,52.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(46,'SQL5',52.5,1,52.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(47,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(47,'DB2R',45,4,180);

-- INSERT INTO INVOICELINEITEMS VALUES(48,'A2VB',62.5,1,62.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(1,'A2VB',30.5,30,915);
-- INSERT INTO INVOICELINEITEMS VALUES(18,'my  ',20,2,40); 
-- INSERT INTO INVOICELINEITEMS VALUES(18,'MVB5',52.5,3,157.5);  
-- INSERT INTO INVOICELINEITEMS VALUES(122,'ADV2',52.5,3,157.5); 
-- INSERT INTO INVOICELINEITEMS VALUES(122,'A2C#',52.5,1,52.5);  
-- INSERT INTO INVOICELINEITEMS VALUES(52,'DB1R',42,1,42); 
-- INSERT INTO INVOICELINEITEMS VALUES(52,'DB2R',45,2,90); 
-- INSERT INTO INVOICELINEITEMS VALUES(52,'A2VB',52.5,3,157.5);  
-- INSERT INTO INVOICELINEITEMS VALUES(52,'PST ',123,2,246); 
-- INSERT INTO INVOICELINEITEMS VALUES(52,'ora ',300,3,900); 
-- INSERT INTO INVOICELINEITEMS VALUES(52,'SQL5',52.5,3,157.5);  
-- INSERT INTO INVOICELINEITEMS VALUES(122,'A2VB',52.5,2,105);   

-- INSERT INTO INVOICELINEITEMS VALUES(122,'DB1R',42,2,84);
-- INSERT INTO INVOICELINEITEMS VALUES(18,'CRFC',50,2,100);
-- INSERT INTO INVOICELINEITEMS VALUES(18,'ADV2',52.5,1,52.5);   
-- INSERT INTO INVOICELINEITEMS VALUES(123,'CRFC',50,12,600);
-- INSERT INTO INVOICELINEITEMS VALUES(123,'ADV2',52.5,2,105);   
-- INSERT INTO INVOICELINEITEMS VALUES(124,'hhhhhhhhhh',78.01,10,780.1); 
-- INSERT INTO INVOICELINEITEMS VALUES(124,'xxxxxxxxxx',78.4,5,392);   
-- INSERT INTO INVOICELINEITEMS VALUES(125,'A2C#',52.5,2,105);   
-- INSERT INTO INVOICELINEITEMS VALUES(125,'A2VB',52.5,3,157.5); 
-- INSERT INTO INVOICELINEITEMS VALUES(125,'ADV2',52.5,6,315);   
-- INSERT INTO INVOICELINEITEMS VALUES(125,'DB1R',42,5,210); 
-- INSERT INTO INVOICELINEITEMS VALUES(126,'ADV2',52.5,2,105);   
-- INSERT INTO INVOICELINEITEMS VALUES(126,'DB1R',42,1,42);

-- INSERT INTO INVOICELINEITEMS VALUES(126,'DB2R',45,2,90);
-- INSERT INTO INVOICELINEITEMS VALUES(126,'A2VB',52.5,2,105);   
-- INSERT INTO INVOICELINEITEMS VALUES(127,'CRFC',50,1,50);
-- INSERT INTO INVOICELINEITEMS VALUES(127,'ADV2',52.5,1,52.5);  
-- INSERT INTO INVOICELINEITEMS VALUES(127,'DB1R',42,1,42);
-- INSERT INTO INVOICELINEITEMS VALUES(127,'DB2R',45,2,90); 

--INSERTAR EN EMPLEADOS

INSERT INTO EMPLOYEES VALUES(31,'Pilco','Ronald','Licenciado','01/02/2015','27');  
INSERT INTO EMPLOYEES VALUES(22,'FLORES','MARCELO','Tecnologo','15/02/2015','619'); 
INSERT INTO EMPLOYEES VALUES(24,'Morales','Humberto','Tecnologo','01/02/2015','736');   
INSERT INTO EMPLOYEES VALUES(26,'Llerena','Armando','Licenciado','24/02/2015','65890'); 
INSERT INTO EMPLOYEES VALUES(27,'Alvarez','Eddison','Ingeniero','15/02/2015','2015');
INSERT INTO EMPLOYEES VALUES(41,'Llerena','Carlos','Ingeniero','11/02/2015','870'); 

--INSERTAR EN CLIENTES

INSERT INTO CUSTOMERS VALUES(3,'Antony, Abdul','1109 Powderhorn Drive','Fayetteville','NC','28314');  
INSERT INTO CUSTOMERS VALUES(4,'Smith, Ahmad','2509 South Crescent','Savanna','IL','61074');
INSERT INTO CUSTOMERS VALUES(5,'Chen, Rabi','2273 N. Essex L','Murfreesboro','T ','37130');  
INSERT INTO CUSTOMERS VALUES(6,'Nuckols, Heather','150 Hayes St','Elgi','IL','60120'); 
INSERT INTO CUSTOMERS VALUES(7,'Lutonsky, Christopher','293 Old Holcomb Bridge Way','Woodland Hills','CA','91365'); 
INSERT INTO CUSTOMERS VALUES(8,'Reddy, Aj','P.O. Box 9802','Plano','TX','75025-0587');   
INSERT INTO CUSTOMERS VALUES(9,'Rascano, Darrell','16 Remington Dr. E','Rancho Cordova','CA','95760');
INSERT INTO CUSTOMERS VALUES(10,'Johnson, Ajith','2200 Old Germantown Road','McGregor','CA','55555');  
INSERT INTO CUSTOMERS VALUES(11,'Patwardhan, Joh','2512 Shades Crest Rd','BethelPark','PA','15102');  
INSERT INTO CUSTOMERS VALUES(12,'Swenson, Vi','102 Forest Drive','Albany','OR','97321');   
INSERT INTO CUSTOMERS VALUES(13,'Nichols, Nadine','7403 Twin Brooks Blvd','Rogers','AR','72756');  
INSERT INTO CUSTOMERS VALUES(14,'Guthrie, Rawle','3011 Belden Street','Phoenix','AZ','85023');  
INSERT INTO CUSTOMERS VALUES(15,'Nguyen, Alliso','4100 Coca-Cola Plaza','Memphis','T ','38118');
INSERT INTO CUSTOMERS VALUES(16,'Kandregula, Howard','534 Radar Road','Oklahoma City','OK','73132');   
INSERT INTO CUSTOMERS VALUES(17,'Yudkevich, Ed','1701 E. 12Th Street','Olathe','KS','66062');
INSERT INTO CUSTOMERS VALUES(18,'Jii, ','1678 Plateau Dr','Dracut','MA','01826  ');   
INSERT INTO CUSTOMERS VALUES(19,'Schreiber, Nick','1815 E. Newberry St','Lawrenceville','NJ','08648');
INSERT INTO CUSTOMERS VALUES(20,'Chamberland, Sarah','1942 S. Gaydon Avenue','Doraville','CA','30340');  
INSERT INTO CUSTOMERS VALUES(21,'Goldman, Do','Po Box 645910','Newark','NJ','07103');   
INSERT INTO CUSTOMERS VALUES(23,'Newlin, Sherma','2400 Bel Air, Apt.345','Broomfield','CO','80020');
INSERT INTO CUSTOMERS VALUES(24,'Chavez, Gregory','6472 Mll Ct','Frederick','MD','21703');
INSERT INTO CUSTOMERS VALUES(25,'De la fuente, Cathy','2213 Abbotsford Dr','Dalto','GA','30720'); 
INSERT INTO CUSTOMERS VALUES(26,'Lin, Terri','280 Briarcliff Rd','Springfield','IL','62702'); 
INSERT INTO CUSTOMERS VALUES(27,'Mercado, Vincent','637 Fulton Rd,  71','Boise','ID','83704');  
INSERT INTO CUSTOMERS VALUES(28,'Thornton, Sreedhar','2542 N  Mozart','Brookly','NY','11229');  
INSERT INTO CUSTOMERS VALUES(29,'Johnson, Pradeep','P.O. Box 81171','Ws','RI','02890');   
INSERT INTO CUSTOMERS VALUES(30,'Leach, Venkat','12033 Foundation Place','Rowland Hts','CA','91748'); 
INSERT INTO CUSTOMERS VALUES(31,'Muru, Eric','300 Sixth Avenue','Henderso','NV','89052');  
INSERT INTO CUSTOMERS VALUES(32,'Slabicki, Liuy','1979 Marcus Ave.','Westwood','NJ','07675');
INSERT INTO CUSTOMERS VALUES(33,'Lair, Andrew','28 Marblestone Lane','San Francisco','CA','94122'); 
INSERT INTO CUSTOMERS VALUES(34,'Johnson, Waylo','440 Richmond Park East','Hamde','CT','06517-2703 ');  
INSERT INTO CUSTOMERS VALUES(35,'Morgan, Robert','48289 Fremont Blvd','Carrollto','TX','75006');  
INSERT INTO CUSTOMERS VALUES(36,'Annamanaidu, Christia','213 N. College Dr.','Omaha','NE','68127'); 
INSERT INTO CUSTOMERS VALUES(37,'Brown, Phil','860 Summerville Rd','Sioux Falls','SD','57103');   
INSERT INTO CUSTOMERS VALUES(38,'Beier, Aneta','8204 Anderson Road','Temple','TX','76504');   
INSERT INTO CUSTOMERS VALUES(39,'Fernandes, Philip','136 Gales Drive','Richmond Hts','OH','44143'); 
INSERT INTO CUSTOMERS VALUES(40,'Roby, Chris','182 Greylock Parkway','Sacto','CA','95814');   
INSERT INTO CUSTOMERS VALUES(41,'Kumari, Gopinath','35 Manor Dr. Apt# 5-O','Queens Village','NY','11428');
INSERT INTO CUSTOMERS VALUES(42,'Pardo, Harriet','141 Summit Street','Waldorf','M ','56091'); 
INSERT INTO CUSTOMERS VALUES(43,'Haldorai, Dorado','1427 Valleyball','Hulk Morgan','AK','378');   
INSERT INTO CUSTOMERS VALUES(44,'Miller, Jeremy','625 Woodsmoke','Plano','TX','75023'); 
INSERT INTO CUSTOMERS VALUES(45,'Jain, Phyllis','75 Lexington Court','Austi','M ','55912');   
INSERT INTO CUSTOMERS VALUES(46,'Nataraj, Randy','1409 Coliseum Blvd','Wesley Chapel','FL','33544');
INSERT INTO CUSTOMERS VALUES(47,'Sellers, Timothy','13700 Sutton Park Dr N -- #322','Dallas','TX','75287');   
INSERT INTO CUSTOMERS VALUES(48,'Allen, Deanna','766 Willow Ridge Dr','Demotte','I ','46310');
INSERT INTO CUSTOMERS VALUES(49,'Huebner, Walter','100 Peachtree St.','Jacksonville','FL','32217'); 
INSERT INTO CUSTOMERS VALUES(50,'Hutcheson, Larry','2902 Cannons Lane','Coffeyville','KS','67337');   
INSERT INTO CUSTOMERS VALUES(51,'Green, Eduardo','1240 E. Diehl Road','Columbia','SC','29209');   
INSERT INTO CUSTOMERS VALUES(52,'Azure, Mike','304 Combs','Mendo','NY','14606'); 
INSERT INTO CUSTOMERS VALUES(53,'Dardac, Donald','4232 Judah','Irving','TX','75038'); 
INSERT INTO CUSTOMERS VALUES(54,'Deguzman, Jose','4168 Woodland Road','Brookly','NY','11226');
INSERT INTO CUSTOMERS VALUES(55,'Wolff, Jonatha','7921 Lamar','Ann Arbor','MI','48108');
INSERT INTO CUSTOMERS VALUES(56,'Johnson, Mark','1538 Harmon Cove Tower','Greenville','NC','27889');
INSERT INTO CUSTOMERS VALUES(57,'Leach, Ala','147 Bear Creek Pike','Dallas','TX','75218-3995 ');  
INSERT INTO CUSTOMERS VALUES(58,'Marlatt, Robert','P.P. Box 139','Yorktown Heights','NY','10598');  
INSERT INTO CUSTOMERS VALUES(59,'Perlman, Lk','505 Ellis Blvd','Philadelphia','PA','19122-6083 ');  
INSERT INTO CUSTOMERS VALUES(60,'Brown, Scott','919, 137Th Avenue Ne','Kansas City','KS','66102');  
INSERT INTO CUSTOMERS VALUES(61,'Stein, George','95 Carleton St','New Milford','NJ','07646'); 
INSERT INTO CUSTOMERS VALUES(62,'Petway, Robert','303 3Rd Ave Se','Jacksonville','FL','32224');   
INSERT INTO CUSTOMERS VALUES(63,'Robinson, Timothy','3075 Highland Parkway','Westland','MI','48185');   
INSERT INTO CUSTOMERS VALUES(64,'Goodwin, Mark','6639 Capitol Blvd','Montgomery','AL','36130'); 

  
INSERT INTO CUSTOMERS VALUES(65,'Mallipeddi, Rick','1876 Woodhollow Dr','Milpita
s','CA','95035'); 
  
INSERT INTO CUSTOMERS VALUES(66,'Buford, Bry','540 W North West Highway','New Yo
rk','NY','10005');
  
INSERT INTO CUSTOMERS VALUES(67,'Fritz, Mark','16 Erie','Hosuto','TX','77077
'); 
  
INSERT INTO CUSTOMERS VALUES(68,'Hamilton, Kare','18 Marvin Dr., Apt#B-5','Cinci
nnati','OH','45263'); 
  

INSERT INTO CUSTOMERS VALUES(69,'Ybarra, George','6 Oneill Ct','Detroit','MI','4
8206-1775 ');   
  
INSERT INTO CUSTOMERS VALUES(70,'Varghese, Joanne','7178 Talhelm Road','Fort Way
ne','I ','46805-1499 ');
  
INSERT INTO CUSTOMERS VALUES(71,'Santos, Anita','1640 Barrington Lane','Barringt
o','IL','60448'); 
  
INSERT INTO CUSTOMERS VALUES(72,'Kieffer, Jing','1492 Highland Lakes Trail','Rin
ggold','AK','30736'); 
  
INSERT INTO CUSTOMERS VALUES(73,'Seaver, Glenda','23 Holohan Drive','Mountlake T

errace','WA','98043');
  
INSERT INTO CUSTOMERS VALUES(74,'Knox, Lakshma','9074 Estes St','Austi','TX','78
759');
  
INSERT INTO CUSTOMERS VALUES(75,'Wigton, Alex','5033 Montego Bay Dr','Brookly','
NY','11245');   
  
INSERT INTO CUSTOMERS VALUES(76,'Ryan, Jagriti','115 Audubon Cove','Kingsport','
T ','37663');   
  
INSERT INTO CUSTOMERS VALUES(77,'Latheef, Andrea c.','17 Potter Road','Jacksonvi
lle','FL','32256');   

  
INSERT INTO CUSTOMERS VALUES(78,'Konow, Andrew','25677 Wistereia Ct','Greenville
','SC','29607');
  
INSERT INTO CUSTOMERS VALUES(79,'Chang, Simo','8317 Cabin Creek Drive','Oshkosh'
,'WI','54901'); 
  
INSERT INTO CUSTOMERS VALUES(80,'Garcia, Chong','28000 Dequindre','Fairfax','VA'
,'22033');
  
INSERT INTO CUSTOMERS VALUES(81,'Schlusselberg, Brando','303 South Second St.','
Collinsville','IL','62234-2973 ');
  

INSERT INTO CUSTOMERS VALUES(82,'Boan, Dinesh','11582 Rusk Cove','Charlotte','NC
','28270'); 
  
INSERT INTO CUSTOMERS VALUES(83,'Dalton, Tai-ye','115 Tower Drive','Round Rock',
'TX','78681');  
  
INSERT INTO CUSTOMERS VALUES(84,'Wieneke, Frank','2111 Bancroft Way','Birmingham
','AL','35226');
  
INSERT INTO CUSTOMERS VALUES(85,'Trujillo, Thell','1204 Keller Lane','Fairfield'
,'IA','52556'); 
  
INSERT INTO CUSTOMERS VALUES(86,'Ritz, Joe','7404 Lomo Alto','Plano','TX','75024

'); 
  
INSERT INTO CUSTOMERS VALUES(88,'Monse, Charles','5933 6Th Street','Somersert','
NJ','08873');   
  
INSERT INTO CUSTOMERS VALUES(89,'Boswell, Joseph','3131 E. Holcombe Blvd','Shelt
o','CT','06484'); 
  
INSERT INTO CUSTOMERS VALUES(90,'Johnson, Stewart','410 Victory Garden Dr. Apt. 
36','San Diego','CA','92111');
  
INSERT INTO CUSTOMERS VALUES(91,'Cummings, Usha','12033 Foundation Place','Green
ville','TX','75401'); 

  
INSERT INTO CUSTOMERS VALUES(92,'Aguimba, Edward','444 Propsect St','Streamwood'
,'IL','60107'); 
  
INSERT INTO CUSTOMERS VALUES(93,'Lacey, Kimberly','3450 W. Country Club Dr','Mac
omb','MI','48044');   
  
INSERT INTO CUSTOMERS VALUES(94,'Vega, Bharat','3003 N. First St. Ste309','Littl
e Elm','TX','75068'); 
  
INSERT INTO CUSTOMERS VALUES(95,'Cheboli, Walter','4260 Nw 32 Street','Mankato',
'M ','56002');  
  

INSERT INTO CUSTOMERS VALUES(96,'Bawa, Jerry','315 Newport Lane','Rockville','MD
','20850'); 
  
INSERT INTO CUSTOMERS VALUES(97,'Yciano, Nicolette','1295 State Street','Gettysb
urg','PA','17325');   
  
INSERT INTO CUSTOMERS VALUES(98,'Duvall, Billy','Box 123','Fremont','CA','94536 
   ');  
  
INSERT INTO CUSTOMERS VALUES(99,'Trasente, Lucy','51783 Se 7Th Street','Westervi
lle','OH','43081');   
  
INSERT INTO CUSTOMERS VALUES(100,'Hodgkins, Giridhar','814 East Ivy Street','Nyc

','NY','110324   ');
  
INSERT INTO CUSTOMERS VALUES(101,'Goldberg, Seth','4647 Stone Avenue','Huntsvill
e','TX','77320'); 
  
INSERT INTO CUSTOMERS VALUES(102,'Hernandez, Esta','4000 So. 35Th','Hagerstow','
MD','21742');   
  
INSERT INTO CUSTOMERS VALUES(103,'Trent, Janet','13101 Columbia Pike','San Franc
isco','CA','94122');  
  
INSERT INTO CUSTOMERS VALUES(104,'Wheatley, Sathyanarayana','2226 Spring Dusk La
ne','Bloomingdale','NJ','07403'); 

  
INSERT INTO CUSTOMERS VALUES(105,'Williams, Eugene','805D Columbia St.','Flushin
g','NY','11355'); 
  
INSERT INTO CUSTOMERS VALUES(106,'Smisko, Steve','104 Cinnamon Teal Court','Warr
e','MI','48089'); 
  
INSERT INTO CUSTOMERS VALUES(107,'Travis, Jeff','3111 Monument Drive','Milwaukee
','WI','53218');
  
INSERT INTO CUSTOMERS VALUES(108,'Broadhurst, Vito','300 30Th Ave. N. Apt. 4C','
Fennimore','WI','53809');   
  

INSERT INTO CUSTOMERS VALUES(109,'Chansa, Tom','123 Sfsdfsdfsdf','Sacramento','C
A','95820-4617 ');
  
INSERT INTO CUSTOMERS VALUES(110,'Sanjay, Ia','517 So. Main Street','Gainesville
','FL','32301');
  
INSERT INTO CUSTOMERS VALUES(111,'Perkins, Wm','900 Old Country Rd','Grand Prair
ie','TX','75052');
  
INSERT INTO CUSTOMERS VALUES(112,'Paramasivan, Nancy','923 Fuchsia Ave','Alamo',
'CA','94507');  
  
INSERT INTO CUSTOMERS VALUES(113,'Kohli, Carl','51 Mercedes Way','Hollister','CA

','95023'); 
  
INSERT INTO CUSTOMERS VALUES(114,'Nuytten, Kim','8908 So 121St','Chattanooga','T
 ','37404');
  
INSERT INTO CUSTOMERS VALUES(115,'Gagne, Joh','2156 Glencoe Hills Drive.# 6','Su
mter','SC','29154');  
  
INSERT INTO CUSTOMERS VALUES(116,'Sun, Edgar','39 Howell Place','Parsippany','NJ
','07054'); 
  
INSERT INTO CUSTOMERS VALUES(117,'Bounds, Kirk','1818 South 43Rd Street','Collin
sville','IL','62234');

  
INSERT INTO CUSTOMERS VALUES(118,'Palanukumarasamy, Dianna','1521 W Wolfram','Co
lumbia','SC','29223');
  
INSERT INTO CUSTOMERS VALUES(119,'Donahoe, Greg','P. O. Box 2600','St. Paul','M 
','55101'); 
  
INSERT INTO CUSTOMERS VALUES(120,'Bucella, Alex','3451 Fairway Commons Dr','Colo
rado Springs','CO','80907');
  
INSERT INTO CUSTOMERS VALUES(121,'Demith, Bob','20 Carlsbad Rd.','New York','NY'
,'10007');
  

INSERT INTO CUSTOMERS VALUES(122,'Giraka, Eric','115 Williams St Se','Seatle','W
A','98036');
  
INSERT INTO CUSTOMERS VALUES(123,'Jackson, Bill','25-3 Latham Villiage Lane','Pa
rma','OH','44134');   
  
INSERT INTO CUSTOMERS VALUES(124,'Bruch, Camero','10925 South Bryant','Addiso','
TX','75001');   
  
INSERT INTO CUSTOMERS VALUES(125,'Chism, Leslie','123 Main St','Roy','UT','84067
'); 
  
INSERT INTO CUSTOMERS VALUES(126,'Beemer, Steve','1234 Main St','Watertow','CT',

'06795'); 
  
INSERT INTO CUSTOMERS VALUES(127,'Garcia, Dhananjay','9211 Garland','Columbus','
OH','43216');   
  
INSERT INTO CUSTOMERS VALUES(128,'Susai, Jo','42524 Parkhurst Rd.','Mansfield','
MA','02048');   
  
INSERT INTO CUSTOMERS VALUES(129,'Pot, Jonatha','14647 S. Peppermill Ct.','Madis
o','NJ','07940'); 
  
INSERT INTO CUSTOMERS VALUES(130,'fedor, sr., Christy','Beltline Road','Austi','
TX','78745');   

  
INSERT INTO CUSTOMERS VALUES(131,'Wazny, Tina','1025 Cadillac Way','Birmingham',
'AL','35242');  
  
INSERT INTO CUSTOMERS VALUES(132,'Daniel, Jody','1 Enterprise Dr','Phoenix','AZ'
,'85032');
  
INSERT INTO CUSTOMERS VALUES(133,'Binner, Ellis','6855 Woodland Ave','New Milfor
d','CT','06776'); 
  
INSERT INTO CUSTOMERS VALUES(134,'Rasmussen, Da','1066 Hidden Lake Dr','Meride',
'CT','06450');  
  

INSERT INTO CUSTOMERS VALUES(135,'Robinson, Clemente','Sis, 550 Banway Building'
,'Downers Grove','IL','60515');   
  
INSERT INTO CUSTOMERS VALUES(136,'Bennett, Gonza','2707 Villagerive','Baltimore'
,'MD','21229'); 
  
INSERT INTO CUSTOMERS VALUES(137,'Lavallee, Lawrence','2634 Timberbrooke Way','S
an Jua','PR','00936');
  
INSERT INTO CUSTOMERS VALUES(138,'Harris, Peter','3001 S. Congress','Indianapoli
s','I ','46237'); 
  
INSERT INTO CUSTOMERS VALUES(139,'Shukla, An','20743 Chappell Knoll Dr','Appleto

','WI','54913');
  
INSERT INTO CUSTOMERS VALUES(140,'Look, Christina','2014 Widener Place','Amarill
o','TX','79102'); 
  
INSERT INTO CUSTOMERS VALUES(141,'Seale, Brent','1421 Champion Drive Suite 101',
'Carlstadt','NJ','07072');  
  
INSERT INTO CUSTOMERS VALUES(142,'Tuttle, Richard','2829 Bennett Ave','East Nort
hport','NY','11731'); 
  
INSERT INTO CUSTOMERS VALUES(143,'Hardin, Bruce','669 Woodspring Drive','Arlingt
on Hts','IL','60005');

  
INSERT INTO CUSTOMERS VALUES(144,'Erpenbach, Lee','901 Mission Street','Grants P
ass','OR','97526');   
  
INSERT INTO CUSTOMERS VALUES(145,'Tonner, Zheng','57 N Plaza Blvd','Atlanta','GA
','30339-4024 '); 
  
INSERT INTO CUSTOMERS VALUES(146,'Wilbon, Albert','6035 Parkland','Kansas City',
'MO','64141');  
  
INSERT INTO CUSTOMERS VALUES(147,'Horner, Henry','1206 Applegate Prkwy','Indiana
polis','I ','46250'); 
  

INSERT INTO CUSTOMERS VALUES(148,'Buckley, Robert','26280 Bonnie','San Gabriel',
'CA','91776-3916 ');  
  
INSERT INTO CUSTOMERS VALUES(149,'Benedicto, Robert','4140 Alpha Road','Columbia
','SC','29223');
  
INSERT INTO CUSTOMERS VALUES(150,'Corbett, Jayagangadhara','13050 Dahlia Circle,
  122','Sherwood','AK','72120');  
  
INSERT INTO CUSTOMERS VALUES(151,'Bommana, Ilya','1310 Brook St #2A','San Rafael
','CA','94903');
  
INSERT INTO CUSTOMERS VALUES(152,'Rimes, George','977 N. Rustic Circle','Coppera

s Cove','TX','76522');
  
INSERT INTO CUSTOMERS VALUES(153,'Aneshansley, Baskara','6720 Upper York Road','
Ramona','CA','92065');
  
INSERT INTO CUSTOMERS VALUES(154,'Battu, Jeffrey','458 Mehaffey Drive','Succasun
na','NJ','07876');
  
INSERT INTO CUSTOMERS VALUES(155,'Brock, David','651 Brookfield Pkwy','Farmingto
n Hills','MI','48864'); 
  
INSERT INTO CUSTOMERS VALUES(156,'Mogesa, Mohamed','9939, Fredericksburg Rd, Apt
','Overland Park','KS','66212');  

  
INSERT INTO CUSTOMERS VALUES(157,'Abeyatunge, Derek','1414 S. Dairy Ashford','No
rth Chili','NY','14514');   
  
INSERT INTO CUSTOMERS VALUES(158,'Shaffer, Jack','1371 Longford Circle','Tampa',
'FL','33634');  
  
INSERT INTO CUSTOMERS VALUES(159,'Berger, Anil','3968 Holly Dr.','Ediso','NJ','0
8830');   
  
INSERT INTO CUSTOMERS VALUES(160,'Desormeaux, Ram','1219 Redcliffe Road','Sunnyv
ale','CA','94087');   
  

INSERT INTO CUSTOMERS VALUES(161,'Smith, Mark','89-41 210Th Pl','Okc','OK','7311
7');
  
INSERT INTO CUSTOMERS VALUES(162,'Meseguer, Ala','311 Sinclair Frontage Rd','Hou
sto','TX','77047');   
  
INSERT INTO CUSTOMERS VALUES(163,'Alexander, Skip','15 Gettysburg Square  187','
West Hartford','CT','06107'); 
  
INSERT INTO CUSTOMERS VALUES(164,'Louie, Guy','1601 Schlumberger Dr','Baltimore'
,'MD','21228'); 
  
INSERT INTO CUSTOMERS VALUES(165,'Ambati, Greg','1605 Candletree Dr. Suite 114',

'Landover','MD','20785');   
  
INSERT INTO CUSTOMERS VALUES(166,'Perkins, Kosalai','1350 Davenport Mill Rd','Or
lando','FL','55555'); 
  
INSERT INTO CUSTOMERS VALUES(167,'Maksymczak, Timothy','8425 Dolfor Cove','St Lo
uis','MO','63138');   
  
INSERT INTO CUSTOMERS VALUES(168,'Billingsley, Carlos','123 Sw 32Nd St','San Jua
n Capistrano','CA','92675');
  
INSERT INTO CUSTOMERS VALUES(169,'Henry, Benjami','9203 Ivanhoe Road','Phoenix',
'AZ','85016');  

  
INSERT INTO CUSTOMERS VALUES(170,'Srinivas, Nicholas','4792, Apt A, Weybridge Ro
ad','Hendersonville','T ','37075'); 
  
INSERT INTO CUSTOMERS VALUES(171,'Ashley, Karla','108 Randolph Avenue','Sunrise'
,'FL','33351'); 
  
INSERT INTO CUSTOMERS VALUES(172,'Arutla, Jerry l.','209 Ne 6Th','Ontario','CA',
'91762'); 
  
INSERT INTO CUSTOMERS VALUES(173,'Kiss, Michelle','201 Rockview Drive','Baton Ro
uge','LA','70898');   
  

INSERT INTO CUSTOMERS VALUES(174,'Wipfli, Jenny','5502 Elk Hollow Ct','Mcfarland
','WI','53558');
  
INSERT INTO CUSTOMERS VALUES(175,'Perkins, Randy','500 Franklin Trpk','Bellevue'
,'NE','68005'); 
  
INSERT INTO CUSTOMERS VALUES(176,'Lee, Bruce','2388 Springdale Rd., Sw','Powder 
Springs','GA','30127'); 
  
INSERT INTO CUSTOMERS VALUES(177,'Briggs, Greiner','10011 Strathfield L','Vestav
ia','AL','35216');
  
INSERT INTO CUSTOMERS VALUES(178,'Dinan, Kelly','875 Taylor Road','Bayside','NY'

,'11361');
  
INSERT INTO CUSTOMERS VALUES(179,'Molfese, Alexander','34 Knox Lane','Los Angele
s','CA','90068'); 
  
INSERT INTO CUSTOMERS VALUES(180,'Johnson, Neelam','37220, Eisen Hoover Ct','Add
iso','TX','75001');   
  
INSERT INTO CUSTOMERS VALUES(181,'Maberry, Paul','1525 Buchanan St., Nw','Apex',
'NC','27502');  
  
INSERT INTO CUSTOMERS VALUES(182,'Wolfe, Randy','3799 Route 46 East','Columbus',
'GA','31904');  

  
INSERT INTO CUSTOMERS VALUES(183,'Hoffman, Kevi','5375 Mariners Cove Drive','Eve
rett','MA','02149');  
  
INSERT INTO CUSTOMERS VALUES(184,'Rogers, Pete','906 233Rd Pl Ne','Erie','PA','1
6505');   
  
INSERT INTO CUSTOMERS VALUES(185,'Arzuza, Alioune','113 Railroad Ave.','Dallas',
'TX','75252');  
  
INSERT INTO CUSTOMERS VALUES(186,'Williams, Greg','5400 Gingercovedr','Spring Va
lley','NY','10977');  
  

INSERT INTO CUSTOMERS VALUES(187,'Holston, B','1157 Hampton Way Ne','Rancho Cord
ova','CA','95670');   
  
INSERT INTO CUSTOMERS VALUES(188,'Sundaram, Kelly','4905 Dunckel','Orego','WA','
98121');  
  
INSERT INTO CUSTOMERS VALUES(189,'Karri, Lisa','22 Winding Way','Phoenix','AZ','
85016');  
  
INSERT INTO CUSTOMERS VALUES(190,'Yarbro, Joh','2320 Mountain Oaks Lane','Dayto'
,'OH','45415'); 
  
INSERT INTO CUSTOMERS VALUES(191,'Shah, Dave','1251 42Nd St. 4Th Floor','Fayette

ville','AR','72701'); 
  
INSERT INTO CUSTOMERS VALUES(192,'Piper, Ala','341 Carlton Road','Blue Bell','PA
','19422'); 
  
INSERT INTO CUSTOMERS VALUES(193,'Paramasivam, Greg','1013 N. Franklin St','Burn
sville','M ','55306');
  
INSERT INTO CUSTOMERS VALUES(194,'Wallace, Stephe','63 N. Victor Ave.','Tallahas
see','FL','32399-0450 ');   
  
INSERT INTO CUSTOMERS VALUES(195,'Zimmer, Jia','4633 Tarsall Ct','Cinnaminso','N
J','08077-2308 ');

  
INSERT INTO CUSTOMERS VALUES(196,'Barksdale, Kare','214 Main St  249','Housto','
TX','77021');   
  
INSERT INTO CUSTOMERS VALUES(197,'Bilodeau, Kenendy','One Sbc Center','Ediso','N
J','08817');
  
INSERT INTO CUSTOMERS VALUES(198,'Gilliam, James','1910 Patricia','Matteso','IL'
,'60443');
  
INSERT INTO CUSTOMERS VALUES(199,'Abueg, Do','901 N. Lake Destiny','Montvale','N
J','07645');
  

INSERT INTO CUSTOMERS VALUES(200,'Taliaferro, Eric','2101 E Coliseum Blvd','West
mont','IL','60559');  
  
INSERT INTO CUSTOMERS VALUES(201,'Hull, Tom','301 W. Bay St.','Natick','MA','017
60'); 
  
INSERT INTO CUSTOMERS VALUES(202,'Beleford, Njansi','2136 E Main St','Collinsvil
le','IL','62234');
  
INSERT INTO CUSTOMERS VALUES(203,'Kanapilly, Bill','443 Eldridge Rd','Norcross',
'GA','30096');  
  
INSERT INTO CUSTOMERS VALUES(204,'Smith, Chris','14254 W Center Dr','Levittow','

PA','19055');   
  
INSERT INTO CUSTOMERS VALUES(205,'Blasy, Howard','10 Blue Ravine','Plano','TX','
75074');  
  
INSERT INTO CUSTOMERS VALUES(206,'Szara, Elle','714 P Street','Jacksonville','FL
','32202'); 
  
INSERT INTO CUSTOMERS VALUES(207,'Montenegro, M.e','722 N. Broadway','Oakland','
CA','94612');   
  
INSERT INTO CUSTOMERS VALUES(208,'Cullity, Yolanda','312 S. Combs','Norwood','MA
','02062'); 

  
INSERT INTO CUSTOMERS VALUES(209,'Gamba, Jeffrey','726 Brender Lane','Hermitage'
,'T ','37076'); 
  
INSERT INTO CUSTOMERS VALUES(210,'Salazar, Sidney','5845 S. 2325 W.','St Louis',
'MO','63129');  
  
INSERT INTO CUSTOMERS VALUES(211,'Wheeler, Caroline','185 Whiting Lane','Madiso'
,'WI','53704'); 
  
INSERT INTO CUSTOMERS VALUES(212,'Beck, Mike','5316 Easthorpe Drive','Nutley','N
J','07109');
  

INSERT INTO CUSTOMERS VALUES(213,'Browning, Albert','1  E. Telecom Parkway','Dul
uth','GA','30097');   
  
INSERT INTO CUSTOMERS VALUES(214,'Uchendu, Jim','4905 Maffitt Place','Ba','OK','
74011');  
  
INSERT INTO CUSTOMERS VALUES(215,'Robersone, Sumanta','206 Mc Lain Rd.','Atlanta
','GA','30313');
  
INSERT INTO CUSTOMERS VALUES(216,'Brown, Bob','100 Schooner Way','Bedford','OH',
'44146'); 
  
INSERT INTO CUSTOMERS VALUES(217,'Boos, James','7647 Ellington Place','Holmdel',

'NY','07733');  
  
INSERT INTO CUSTOMERS VALUES(218,'Cooke, Arpa','9834 Morgan Meadows Cove','Brook
ly','NY','11236');
  
INSERT INTO CUSTOMERS VALUES(219,'Morisset, Chou','14120 Twisting Lane','West Pa
lm','FL','32106');
  
INSERT INTO CUSTOMERS VALUES(220,'Carroll, Steve','560 Main Street   416','Roger
s','AR','72756'); 
  
INSERT INTO CUSTOMERS VALUES(221,'Lawrence, Nunzio','87 Cannon Ridge Drive','Woo
dside','NY','11377'); 

  
INSERT INTO CUSTOMERS VALUES(222,'Suyam, Steve','1486 Neil Ave','Gilbert','AZ','
85040');  
  
INSERT INTO CUSTOMERS VALUES(223,'Romano, B.j.','47715 Freedom Valley','Bosto','
MA','02116');   
  
INSERT INTO CUSTOMERS VALUES(224,'Daniels, Joh','1417 Deer Spring Court','Fairfa
x','VA','22031'); 
  
INSERT INTO CUSTOMERS VALUES(225,'Milke, Paul','Po Box 846','Raleigh','NC','2760
4');
  

INSERT INTO CUSTOMERS VALUES(226,'Rocca, Cary','8619 W. Summerdale  1','Oakland'
,'CA','94612'); 
  
INSERT INTO CUSTOMERS VALUES(227,'Hassan, Robert','1221 Idaho St','Altoona','PA'
,'16602');
  
INSERT INTO CUSTOMERS VALUES(228,'Sadras, Terry','43-70, Kissena Blvd.,','Bellev
ille','IL','62223');  
  
INSERT INTO CUSTOMERS VALUES(229,'Rivera, Pramod','2203 , Good Shepherd Way','So
lo','OH','44139');
  
INSERT INTO CUSTOMERS VALUES(230,'Walters, Tim','9315 Avenue A','Akro','OH','443

13'); 
  
INSERT INTO CUSTOMERS VALUES(231,'Lee, Andra','8831 Park Central Drive','Beaco',
'NY','12508');  
  
INSERT INTO CUSTOMERS VALUES(232,'Murphy, Dea','105 White Lane','Phoenix','AZ','
85032');  
  
INSERT INTO CUSTOMERS VALUES(233,'Kittendorf, Joe','6430 95th Avenue','Napervill
e','IL','60623'); 
  
INSERT INTO CUSTOMERS VALUES(234,'Liao, Stuart','4070 Fisher Road','Charlotte','
NC','28215');   

  
INSERT INTO CUSTOMERS VALUES(235,'Tabor, Michael','105 Shelley Avenue','Beaverto
','OR','97007');
  
INSERT INTO CUSTOMERS VALUES(236,'Burt, Myro','3201 Clayton Road','Huntingto','A
R','72940');
  
INSERT INTO CUSTOMERS VALUES(237,'Erikson, David','805-D Columbia St','Concord',
'NH','03301');  
  
INSERT INTO CUSTOMERS VALUES(238,'Rathmann, Mark','4107C Carrollton Ct','Rancho 
Cordova','CA','95670-4502 '); 
  

INSERT INTO CUSTOMERS VALUES(239,'Anderson, Jeff','3625 Duval Rd #223','Housto',
'TX','77045');  
  
INSERT INTO CUSTOMERS VALUES(240,'Nguyen, Eddie','205A E Main St','Housto','TX',
'77013'); 
  
INSERT INTO CUSTOMERS VALUES(241,'Diop, Joh','6318 Towncrest Court','South Pasad
ena','CA','91030');   
  
INSERT INTO CUSTOMERS VALUES(242,'Hemmer, Deepanja','2020 Oldfields Circle S Dr'
,'Dallas','TX','75208');
  
INSERT INTO CUSTOMERS VALUES(243,'Gajjela, Jim','1001 Avenue Of The Americas','N

elsonville','OH','45764');  
  
INSERT INTO CUSTOMERS VALUES(244,'Gigante, Kathy','P O Box 25009','Poughkeepsie'
,'NY','12601'); 
  
INSERT INTO CUSTOMERS VALUES(245,'Walker, Walter','2415 First Avenue','New York'
,'NY','10018'); 
  
INSERT INTO CUSTOMERS VALUES(246,'Viswanathan, Howard','37890 Westwood Cir. Apt 
205','Hindsboro','IL','61930');   
  
INSERT INTO CUSTOMERS VALUES(247,'Chu, Darre','9  Campus Dr.','Horsham','PA','19
044');

  
INSERT INTO CUSTOMERS VALUES(248,'Zmaczynski, Mike','3907 78Th Drive E','Schaumb
urg','IL','60195');   
  
INSERT INTO CUSTOMERS VALUES(249,'Bradley, Raj','1115 Huntington Dr.  B','Aliqui
ppa','PA','15001');   
  
INSERT INTO CUSTOMERS VALUES(250,'Drake, Doug','846 President St','Linde','NJ','
07036');  
  
INSERT INTO CUSTOMERS VALUES(252,'Balliet, Steve','1 New York Plaza','Santa Ana'
,'CA','92703'); 
  

INSERT INTO CUSTOMERS VALUES(253,'Bertone, Robert','4627 Blanche Road  #168','Au
sti','TX','78759');   
  
INSERT INTO CUSTOMERS VALUES(254,'Harding, Shaw','3480 W 135Th St','Novato','CA'
,'94947');
  
INSERT INTO CUSTOMERS VALUES(255,'Boyle, Teresa','225 Mt Vernon Dr','Cerritos','
CA','90703');   
  
INSERT INTO CUSTOMERS VALUES(256,'Mahodaya, Test','351 Crossing Blvd','Anywhere'
,'CA','90210'); 
  
INSERT INTO CUSTOMERS VALUES(257,'Koch, Robert','222South Riverside Plaza','Deca

tur','GA','30034');   
  
INSERT INTO CUSTOMERS VALUES(258,'Curless, Darald','P.O. Box 866642','West Hills
','CA','91304');
  
INSERT INTO CUSTOMERS VALUES(259,'Rusoff, David','3305, Society Drv','Lincol','N
E','68506-4807 ');
  
INSERT INTO CUSTOMERS VALUES(260,'Hester, Maurice','2576 Sheppard Road','Kennewi
ckm','WA','99336m   ');   
  
INSERT INTO CUSTOMERS VALUES(261,'Herbert, Richard','542, Maple Dr','Charlotte',
'NC','28211');  

  
INSERT INTO CUSTOMERS VALUES(262,'Mattson, Debora','1701 Telfair Chase Way','Sac
ramento','CA','95814'); 
  
INSERT INTO CUSTOMERS VALUES(263,'Allen, Joel','2220 W Mission Ln Apt 1127','Hil
liard','OH','43026'); 
  
INSERT INTO CUSTOMERS VALUES(264,'King, Radhakrishna','901 S. Central Expressway
','Charlesto','SC','29407');
  
INSERT INTO CUSTOMERS VALUES(265,'Szydlow, Raymond','1624 Brougham Place','Colum
bus','GA','31904');   
  

INSERT INTO CUSTOMERS VALUES(266,'Lumpkin, Christopher','100 Church Street','Col
umbus','GA','31901'); 
  
INSERT INTO CUSTOMERS VALUES(267,'Ostrov, Arnold','Box 183','Harrisburg','PA','1
7110');   
  
INSERT INTO CUSTOMERS VALUES(268,'Chinna, Larry','2300 Southeastern Ave','Mariet
ta','GA','30062');
  
INSERT INTO CUSTOMERS VALUES(269,'Shellabarger, Mark','34613 Winslow Ter','Banno
ckbur','IL','60015'); 
  
INSERT INTO CUSTOMERS VALUES(270,'Duncan, Ted','1003 N. Delano Ave','Westminster

','CA','92683');
  
INSERT INTO CUSTOMERS VALUES(271,'Harke, Richard','300 Mustang St','Hazelwood','
MO','63042');   
  
INSERT INTO CUSTOMERS VALUES(272,'Craig, Jj','1430 Sw 12Th Ave.  1314','Stamford
','CT','06906');
  
INSERT INTO CUSTOMERS VALUES(273,'Kuiu, Ram','229 Strawtown Rd','North Bend','OH
','45052'); 
  
INSERT INTO CUSTOMERS VALUES(274,'Johnson, Scott','14 Horseshoe Lane','Carver','
MA','02330');   

  
INSERT INTO CUSTOMERS VALUES(275,'Wicks, David','34-52 60Th Street','Maryland He
ights','MO','63043-3961 '); 
  
INSERT INTO CUSTOMERS VALUES(276,'Schuh, Max','730 Opening Hill Rd','Lauderhill'
,'FL','33313'); 
  
INSERT INTO CUSTOMERS VALUES(277,'Dawson, Srividhya','907, Lake Run Cir','Falss 
Church','VA','22041-2536 ');
  
INSERT INTO CUSTOMERS VALUES(278,'Melamud, Tammy','1345 Avenue Of The Americas',
'Cleveland','OH','44111');  
  

INSERT INTO CUSTOMERS VALUES(279,'Woo, Kevi','1108 W. Indiana Ave.','Elk Grove',
'CA','95758');  
  
INSERT INTO CUSTOMERS VALUES(280,'White, Barbara','3400 Richmond Parkway #3423',
'Bristol','CT','06010');
  
INSERT INTO CUSTOMERS VALUES(281,'Schumer, Richard','East Remington Drive','Wood
stock','GA','30188'); 
  
INSERT INTO CUSTOMERS VALUES(282,'Brownstein, Ruth','6142C S. Kensington Ave.','
Boise','ID','83278'); 
  
INSERT INTO CUSTOMERS VALUES(283,'Demers, Ro','4Th Floor  F6-F266-04-1','Conyers

','GA','30013');
  
INSERT INTO CUSTOMERS VALUES(284,'Vennapusa, Rani','7895 Surreywood Dr.','Dallas
','TX','75218');
  
INSERT INTO CUSTOMERS VALUES(285,'Jefferies, Gloria','Matera St','San Bruno','CA
','94066'); 
  
INSERT INTO CUSTOMERS VALUES(286,'Underwood, Al','3520 Twilight Dr','Indianapoli
s','I ','46227'); 
  
INSERT INTO CUSTOMERS VALUES(287,'Kk, Darnell','1121 Tama','Middletow','RI','028
42'); 

  
INSERT INTO CUSTOMERS VALUES(288,'Douglas, Bikash','2220 Canton St  Loft 301','C
olumbus','WI','53925'); 
  
INSERT INTO CUSTOMERS VALUES(289,'Drebenstedt, Thomas','11 Main Street','Florham
 Park','NJ','07932'); 
  
INSERT INTO CUSTOMERS VALUES(290,'Turner, Eric','1728 S. 15Th','Arvada','CO','80
002');
  
INSERT INTO CUSTOMERS VALUES(291,'Volkov, Jim','12033 Foundation Place','Chicago
','IL','60618');
  

INSERT INTO CUSTOMERS VALUES(292,'Westemeier, Linda','722 N Broadway','Jonesboro
','AR','72401');
  
INSERT INTO CUSTOMERS VALUES(293,'Disanto, Be','402 Clover Springs Drive','Irvin
e','CA','92612'); 
  
INSERT INTO CUSTOMERS VALUES(294,'Stroede, George','14115 Fleetwell','Washingto'
,'DC','20065'); 
  
INSERT INTO CUSTOMERS VALUES(295,'Long, Leo','16 Saint Mary Drive','Scappoose','
OR','97056-4484 ');   
  
INSERT INTO CUSTOMERS VALUES(296,'Parmelee, Robert','1810 Berry L','Commerce','T

X','75428');
  
INSERT INTO CUSTOMERS VALUES(297,'Smith, Deb','985 Michigan Av','Lakewood','CO',
'80228'); 
  
INSERT INTO CUSTOMERS VALUES(298,'Smit, Rekha','Computer Science Department','To
peka','KS','66612');  
  
INSERT INTO CUSTOMERS VALUES(299,'Hall, An','114 12Th Ave Nw','Tallahassee','FL'
,'32301');
  
INSERT INTO CUSTOMERS VALUES(300,'Shaw, Ronald','656 Riverside Dr','Tusti','CA',
'92780'); 

  
INSERT INTO CUSTOMERS VALUES(301,'Gujja, Anthony','4747 Mclane Parkway','Irving'
,'TX','75038'); 
  
INSERT INTO CUSTOMERS VALUES(302,'Kundargi, Danial','57 Nevada Dr.','Alpharetta'
,'GA','30004'); 
  
INSERT INTO CUSTOMERS VALUES(303,'Andrews, Ashok','949 Rockybrook Drive','Raleig
h','NC','27613'); 
  
INSERT INTO CUSTOMERS VALUES(304,'Blanchard, Eilee','11 Harbor Woods Circle','Ta
llahassee','FL','32312');   
  

INSERT INTO CUSTOMERS VALUES(305,'Cao, Kelly','906 Dryden Ave','Atlanta','GA','3
0303-3404 ');   
  
INSERT INTO CUSTOMERS VALUES(306,'Bobson, Manohar','2200 Cardinal Drive','Hermos
a Beach','CA','90254'); 
  
INSERT INTO CUSTOMERS VALUES(307,'Valentin-eggert, Michael','140, Broadway','Ind
ianapolis','I ','46221');   
  
INSERT INTO CUSTOMERS VALUES(308,'Pierre, Robert','155 Grisseltail Rd','Park Rid
ge','IL','60056');
  
INSERT INTO CUSTOMERS VALUES(309,'Grampsas, Jiying','1200 Wooded Acres Dr.','Ame

s','IA','50010'); 
  
INSERT INTO CUSTOMERS VALUES(310,'Jeffcoat, Nelso','5244 West 139Th Street','Por
tland','TX','78374'); 
  
INSERT INTO CUSTOMERS VALUES(311,'Casoli, Da','5 Conrad Court','Prairie Village'
,'KS','66208'); 
  
INSERT INTO CUSTOMERS VALUES(312,'Hidalgo, Fgsdg','405 Fayette Pike','Austi','TX
','78704'); 
  
INSERT INTO CUSTOMERS VALUES(313,'Murphy, Coli','3831 Pinetree Dr.','Asheville',
'NC','28806');  

  
INSERT INTO CUSTOMERS VALUES(314,'Gonzalles, Maiv','10610 Morado Circle','Jopli'
,'MO','64801'); 
  
INSERT INTO CUSTOMERS VALUES(315,'Reinarz, Craig','1339 Contra Costa Drive','Ber
nville','PA','19506');
  
INSERT INTO CUSTOMERS VALUES(316,'Appandai, Curtis','443 Airpark Rd','Grand Prai
rie','TX','75052');   
  
INSERT INTO CUSTOMERS VALUES(317,'Brown, Srikanth','1155 Warburton Ave','Richmon
d','CA','94806'); 
  

INSERT INTO CUSTOMERS VALUES(318,'Avula, Manuel','2217 North Ave','Lake Success'
,'NY','11042'); 
  
INSERT INTO CUSTOMERS VALUES(319,'Mcdermott, Clifford','162 Quail Ru','Chicago',
'IL','60643');  
  
INSERT INTO CUSTOMERS VALUES(320,'Bernard, Subramaniya','125 Raritan Plaza','Bir
mingham','AL','35222'); 
  
INSERT INTO CUSTOMERS VALUES(321,'Sridar, Ashok','5146 Keitts Corner Road','Live
rpool','NY','13090'); 
  
INSERT INTO CUSTOMERS VALUES(322,'Lorusso, Walt','6509 Rosemeadows Dr','Las Cruc

es','NM','88003');
  
INSERT INTO CUSTOMERS VALUES(323,'Marshburn, Sridhar reddy','1530 Broadway Road'
,'Brookly','NY','11219');   
  
INSERT INTO CUSTOMERS VALUES(324,'Brown, Connie','10302 Joan Drive','Appleto','W
I','54915');
  
INSERT INTO CUSTOMERS VALUES(325,'Tucker, Bill','3003 North First Street','Milwa
ukee','WI','53202');  
  
INSERT INTO CUSTOMERS VALUES(326,'Howell, Kim','4010 Bob Wallace Ave Apt 3','Ren
to','WA','98056');

  
INSERT INTO CUSTOMERS VALUES(327,'Bostick, Alle','7205 None Rd.','Montgomery','W
V','25136');
  
INSERT INTO CUSTOMERS VALUES(328,'Alsaidi, Jim','712 White Oak','Apopka','FL','3
2712');   
  
INSERT INTO CUSTOMERS VALUES(329,'Delatte, William','2521 Old Stone Mill Drive',
'Lewisville','TX','75067'); 
  
INSERT INTO CUSTOMERS VALUES(330,'Krishnamurthy, William','1110 Ne 12Th St','Cra
nbury','NJ','08512'); 
  

INSERT INTO CUSTOMERS VALUES(331,'Howard, Denise','1517 Wn Carrier Pkwy. Ste. 15
0','Wincester','T ','37398'); 
  
INSERT INTO CUSTOMERS VALUES(332,'Galloway, Mariola','P.O. Box 250587','New York
','NY','10025');
  
INSERT INTO CUSTOMERS VALUES(333,'Loyal, Chang','R.R. 1  Box 132','Jacksonville'
,'FL','32207-3713 '); 
  
INSERT INTO CUSTOMERS VALUES(334,'Kaphle, Carlos','111 Wall St.','Housto','TX','
77221');  
  
INSERT INTO CUSTOMERS VALUES(335,'Srigiri, Greg','725 Lake St Ne','Wesley Chapel

','NC','28173');
  
INSERT INTO CUSTOMERS VALUES(336,'Mccue, Sreepathi','914 Dundee Ct','Tinlry Park
','IL','60477');
  
INSERT INTO CUSTOMERS VALUES(337,'Morgan, Joh','28 Golden Hill','Tampa','FL','33
615');
  
INSERT INTO CUSTOMERS VALUES(338,'Clegg, Viola','3635 Vista','Mansfield','MO','6
5704');   
  
INSERT INTO CUSTOMERS VALUES(339,'Kanter, Cindy','17909 Peru Rd # 37','Lawrencev
ille','GA','30043-5151 ');  

  
INSERT INTO CUSTOMERS VALUES(340,'Sahoo, Satish','55 Water Street','Lansing','MI
','48917'); 
  
INSERT INTO CUSTOMERS VALUES(341,'D, Elaine','3604 Partridge Path Apt 1','Rancho
 Cordova','CA','95670');
  
INSERT INTO CUSTOMERS VALUES(342,'Sase, Claude','2963 Jones St.','Benicia','CA',
'94510'); 
  
INSERT INTO CUSTOMERS VALUES(343,'Chanduri, Walter c','1331 Jefferson Avenue','D
elray Beach','FL','33445'); 
  

INSERT INTO CUSTOMERS VALUES(344,'Ibarra, Joh','Pob 65','Warminster','PA','18974
'); 
  
INSERT INTO CUSTOMERS VALUES(345,'Phillips, Jeff','223 Sunlit Way','Plymouth','M
I','48170');
  
INSERT INTO CUSTOMERS VALUES(346,'Randazzo, Alaine','Hall St','Blue Mounds','WI'
,'53562');
  
INSERT INTO CUSTOMERS VALUES(347,'Brown, Toni','6050 Crawfordville Rd','Housto',
'TX','77042');  
  
INSERT INTO CUSTOMERS VALUES(348,'Samala, Avelino','117 Beacon Ave','Lawrence','

MI','49064');   
  
INSERT INTO CUSTOMERS VALUES(349,'Shanmugasundaram, Joh','6890 Deer Court','Glen
 Elly','IL','60137'); 
  
INSERT INTO CUSTOMERS VALUES(350,'Posh, Kevra','P.O Box 1452','Jonesboro','AR','
72401');  
  
INSERT INTO CUSTOMERS VALUES(351,'Cuento, Joh','5100 Tipperary','Little Rock','A
R','72022');
  
INSERT INTO CUSTOMERS VALUES(352,'Cate, Kim','123 Wild Lilac Court','San Mateo',
'CA','94402-5009 ');  

  
INSERT INTO CUSTOMERS VALUES(353,'Johnson, Joh','23 Main Street','Lawrenceville'
,'GA','30043'); 
  
INSERT INTO CUSTOMERS VALUES(354,'Bhatt, Andregene','20533 Sw 2 Nd. Street','Wes
terville Dr W','OH','43082'); 
  
INSERT INTO CUSTOMERS VALUES(355,'Jackson, Alex','1234 Main St.','Doylestow','PA
','18901'); 
  
INSERT INTO CUSTOMERS VALUES(356,'Thelagathoti, Brad','2010 Glass Rd. Ne Apt 210
','Dallas','TX','75211');   
  

INSERT INTO CUSTOMERS VALUES(357,'Hausner, William','2512 N.E. 9 Th St','Valpara
iso','I ','46383');   
  
INSERT INTO CUSTOMERS VALUES(358,'Mead, Aquanetta','2443 Sunset','Kenosha','WI',
'53142'); 
  
INSERT INTO CUSTOMERS VALUES(359,'Vera, Craig','8Th Floor','Columbus','OH','4320
4');
  
INSERT INTO CUSTOMERS VALUES(360,'Meek, Frank reyes','4804 Deer Lake Dr E','Anke
ny','IA','50021');
  
INSERT INTO CUSTOMERS VALUES(361,'Register, Ala','4416 Hartdord Dr.','Southfield

','MI','48075');
  
INSERT INTO CUSTOMERS VALUES(362,'Taraszewski, Michael','1000 I Street','Ozone P
ark','NY','11417');   
  
INSERT INTO CUSTOMERS VALUES(363,'Louis, Leanne','606 Savannah Highway','Tallaha
ssee','FL','32304');  
  
INSERT INTO CUSTOMERS VALUES(364,'Lawson, Sriramana','14160 Red Hill Ave  106','
Springfield','IL','62704'); 
  
INSERT INTO CUSTOMERS VALUES(365,'Johnson, Anne','4511 Hezekiah Pl','Temple','TX
','76504'); 

  
INSERT INTO CUSTOMERS VALUES(366,'Bannur, Siva','252 - 85 Leith Road','Milwaukee
','WI','53202');
  
INSERT INTO CUSTOMERS VALUES(367,'Foote, Debra','15769 Hele','Buffalo Grove','IL
','60089'); 
  
INSERT INTO CUSTOMERS VALUES(368,'Mcdonnell, Siddharth','2616 Beema','New Market
','MD','21774');
  
INSERT INTO CUSTOMERS VALUES(369,'Lakshmanaraju, Jeff','1388 Warner Ave','Berkel
ey','CA','94720');
  

INSERT INTO CUSTOMERS VALUES(370,'Womack, Gail','109 North Street','Philadelphia
','PA','19146-1716 ');
  
INSERT INTO CUSTOMERS VALUES(371,'Burger, Michael','2325 Keaton Ave., Apt. F','M
atawa','NJ','07747'); 
  
INSERT INTO CUSTOMERS VALUES(372,'B, Rodney','502 N. Jefferson St','Itasca','IL'
,'60143');
  
INSERT INTO CUSTOMERS VALUES(373,'Funai, Margaret','P.O.Box 99220','Moorestow','
NJ','08057');   
  
INSERT INTO CUSTOMERS VALUES(374,'Then, George','85 Notre Dame Dr','Garden Grove

','CA','92840');
  
INSERT INTO CUSTOMERS VALUES(375,'Toocee, Marie','4500 Baymeadows Rd','Concord',
'CA','94519');  
  
INSERT INTO CUSTOMERS VALUES(376,'Chiru, Nate','1609 Ranch View Drive','Bellmawr
','NJ','08031');
  
INSERT INTO CUSTOMERS VALUES(377,'Tester, Steve','2232 Ironwood Ridge Ct','Lowel
l','MA','01854'); 
  
INSERT INTO CUSTOMERS VALUES(378,'Das, Robert','2662, Scotalnd Gree','Yonkers','
NY','10701');   

  
INSERT INTO CUSTOMERS VALUES(379,'Paul, Sam','3249 S. Oak Park Ave','Chicago','I
L','60642');
  
INSERT INTO CUSTOMERS VALUES(380,'Counts, James','W3903 Krueger Rd','New Milford
','NJ','07646');
  
INSERT INTO CUSTOMERS VALUES(381,'Obul, Hari','241 Main St','Temple Terrace','FL
','33637'); 
  
INSERT INTO CUSTOMERS VALUES(382,'Berry, R','513 Little Ave.','Paw Paw','MI','49
079');
  

INSERT INTO CUSTOMERS VALUES(383,'Viswanathan, Said','5 Woodhollow Rd','New York
','NY','10005');
  
INSERT INTO CUSTOMERS VALUES(384,'Graziano, Bob','13101 Columbia Pike','Matthews
','NC','28105');
  
INSERT INTO CUSTOMERS VALUES(385,'Gira, Dava','24 Northfield Rd','Raymore','MO',
'64083'); 
  
INSERT INTO CUSTOMERS VALUES(386,'Howe, Samuel','927A E. Center St.','Pittsburgh
','PA','15239-2324 ');
  
INSERT INTO CUSTOMERS VALUES(387,'Cox, Lawrence','10 Park Plaza','Cloverdale','C

A','95425-5440 ');
  
INSERT INTO CUSTOMERS VALUES(388,'Wright, Tanya','415 W Golf Rd','Lincolnshire',
'IL','60069');  
  
INSERT INTO CUSTOMERS VALUES(389,'Matthes, Mark','750 Crown Cove','Salinas','CA'
,'93908');
  
INSERT INTO CUSTOMERS VALUES(390,'Riza, Matthew','1263 Greenleaf Loop','Lake Osw
ego','OR','97035');   
  
INSERT INTO CUSTOMERS VALUES(391,'Castle, Kenneth','1536 Chicago Blvd','Clearwat
er','FL','33756');

  
INSERT INTO CUSTOMERS VALUES(392,'Walker, Bob','2200 S Fort Apache #2029','Sunny
vale','CA','94087');  
  
INSERT INTO CUSTOMERS VALUES(393,'Lockhart, Jagloo','6349 Beechwood Drive','Des 
Moines','IA','50310');
  
INSERT INTO CUSTOMERS VALUES(394,'Verma, Jose','1406 17Th Ave','N.M.','FL','3318
1');
  
INSERT INTO CUSTOMERS VALUES(395,'Burchard, Jay','17440 N Tatum Blvd','Indianapo
lis','I ','46206');   
  

INSERT INTO CUSTOMERS VALUES(396,'Loper, Demetria','3801 S. Capital Of Texas Hw'
,'Hackettstow','NJ','07840'); 
  
INSERT INTO CUSTOMERS VALUES(397,'Hollingsworth, Ed','626 Picher','Columbus','OH
','43215'); 
  
INSERT INTO CUSTOMERS VALUES(398,'Wise, Norm','1212 N. Lasalle St., #2201','Ft T
homas','KY','41075'); 
  
INSERT INTO CUSTOMERS VALUES(399,'Lipsig, Seth','16 Shallowford Rd.','Chicago','
IL','60656');   
  
INSERT INTO CUSTOMERS VALUES(400,'Litterson, Anthony','901 S. National Ave.','Ph

ila.','PA','19105');  
  
INSERT INTO CUSTOMERS VALUES(401,'Antalocy, S.','P.O. Box 336','Seattle','WA','9
8155');   
  
INSERT INTO CUSTOMERS VALUES(402,'Nair, Phalo','214 Angela Ave','Jersey City','N
J','07304');
  
INSERT INTO CUSTOMERS VALUES(403,'Roush, M','5111 Ambergate L','Chapi','SC','290
36'); 
  
INSERT INTO CUSTOMERS VALUES(404,'Williams, Bobby','9001 Southbay Drive','Bronx'
,'NY','10467'); 

  
INSERT INTO CUSTOMERS VALUES(405,'Burnett, Muralikrishna','60 Coppermine Road','
Naperville','IL','60540');  
  
INSERT INTO CUSTOMERS VALUES(406,'Agarwala, Troy','2308 Fair St.','Wapakoneta','
OH','45895');   
  
INSERT INTO CUSTOMERS VALUES(407,'Torr, James','465 Buckland Hills Dr. Apt 311',
'Dubli','NY','90210');
  
INSERT INTO CUSTOMERS VALUES(408,'Anderson, Ala','15650A Vineyard Blvd  143','Al
buquerque','NM','87101');   
  

INSERT INTO CUSTOMERS VALUES(409,'Lowery, Shane','1127 Herbert J.','Philadelphia
','PA','19153');
  
INSERT INTO CUSTOMERS VALUES(410,'Syed, Mike','2501 Mcgee','Horn Lake','MS','386
37'); 
  
INSERT INTO CUSTOMERS VALUES(411,'Harrison, Jeff','2560 W. Shaw L','Dallas','TX'
,'75201');
  
INSERT INTO CUSTOMERS VALUES(412,'Dunlavy, Kare','1707 4Th Ave Se','Anytow','CO'
,'80204');
  
INSERT INTO CUSTOMERS VALUES(413,'Fgsgsg, Senthil','2025 E Campbell   #143','Ind

ianapolis','I ','46228-3356 ');   
  
INSERT INTO CUSTOMERS VALUES(414,'Vang, Karl','327 Franklin Street','Edina','M '
,'55435');
  
INSERT INTO CUSTOMERS VALUES(415,'Green, Etha','810 First Street Ne','Oakland','
CA','94612');   
  
INSERT INTO CUSTOMERS VALUES(416,'Elseman, Felix','12 E.31St St. Ste 1205','W. C
ovina','CA','91719'); 
  
INSERT INTO CUSTOMERS VALUES(417,'Blackman, Armando','6333 Mount Ada Rd','Alphar
etta','GA','30004');  

  
INSERT INTO CUSTOMERS VALUES(418,'Page, Patrick','505 Main St','Williamsville','
NY','14221-4520 ');   
  
INSERT INTO CUSTOMERS VALUES(419,'Vidal, William','43 Kraft L','Springfield','MA
','01111-0001 '); 
  
INSERT INTO CUSTOMERS VALUES(420,'Schulte, Romi','147 Afton Ave.','Chicago','IL'
,'60626');
  
INSERT INTO CUSTOMERS VALUES(421,'Allen, Craig','P.O. Box 50016','Pullma','WA','
99164');  
  

INSERT INTO CUSTOMERS VALUES(422,'Sowell, Janet','189 Commcerce Court','Baltimor
e','MD','21201'); 
  
INSERT INTO CUSTOMERS VALUES(423,'Rennells, Ram','310 N. Willomet Ave.','Metairi
e','LA','70002'); 
  
INSERT INTO CUSTOMERS VALUES(424,'Rao, Christina','518 Elmwood Terrace','Avenel'
,'NJ','07001'); 
  
INSERT INTO CUSTOMERS VALUES(425,'Phinney, Sue','624 Aiello St','Comstock Park',
'MI','49321-9344 ');  
  
INSERT INTO CUSTOMERS VALUES(426,'Young, Jacquely','11550 Florida Blvd','Richmon

d','VA','23227'); 
  
INSERT INTO CUSTOMERS VALUES(427,'Wade, Jp','6118 Carnation Road','Tallahassee',
'FL','32305');  
  
INSERT INTO CUSTOMERS VALUES(428,'Plasha, Joe','812 West 13Th Street','Akro','OH
','44113'); 
  
INSERT INTO CUSTOMERS VALUES(429,'Perez, Terrence','2325 West Pensacola Street',
'Farmington Hills','MI','48335'); 
  
INSERT INTO CUSTOMERS VALUES(430,'Moore, Richard','78 Mckown Road','Cedar Rapids
','IA','52401');

  
INSERT INTO CUSTOMERS VALUES(431,'Laforest, Do','Plntatio','Atlanta','GA','30324
'); 
  
INSERT INTO CUSTOMERS VALUES(432,'Ayyappan, Andrew','1671 Hampton Knoll Drive','
Markham','IL','60426'); 
  
INSERT INTO CUSTOMERS VALUES(433,'Arrington, Mallikarjuna','2551 Wideworld','Mia
mi','FL','33173');
  
INSERT INTO CUSTOMERS VALUES(434,'Oriol, Cecilia','1108 Fleming Ct.   103','Chan
dler','AZ','85225');  
  

INSERT INTO CUSTOMERS VALUES(435,'Garrison, Joel','16951, Addison Rd','New City'
,'NY','10956-6815 '); 
  
INSERT INTO CUSTOMERS VALUES(436,'Cloud, Kevi','652 N Sam Housto','Jackso','MI',
'49202'); 
  
INSERT INTO CUSTOMERS VALUES(437,'Little, Walto','10566 Tiger Point','Downingtow
','PA','19335');
  
INSERT INTO CUSTOMERS VALUES(438,'Moore, Mv','6315 N 16Th St, 229','Brookly','NY
','11219'); 
  
INSERT INTO CUSTOMERS VALUES(439,'Clark, Donald','1015 E. 20Th St Apt C','Plano'

,'TX','75086'); 
  
INSERT INTO CUSTOMERS VALUES(440,'Vatcheva, Scott','315 Court Street','Marshall'
,'WI','53559'); 
  
INSERT INTO CUSTOMERS VALUES(441,'Owen, Mark','P.O. Box 1537','Belleville','NJ',
'07109'); 
  
INSERT INTO CUSTOMERS VALUES(442,'Meeker, Tsao-shiang','2100 Paul Edwin Terr','O
lathe','KS','66062'); 
  
INSERT INTO CUSTOMERS VALUES(443,'Xiong, J','Po Box 8403','Topeka','KS','66604-1
877 ');   

  
INSERT INTO CUSTOMERS VALUES(444,'Truesdale, David','Po Box 6459','Huntsville','
AL','35805');   
  
INSERT INTO CUSTOMERS VALUES(445,'Miller, Bassam','10 Erick Rd #15','Hyattsville
','MD','20783');
  
INSERT INTO CUSTOMERS VALUES(446,'Stone, Milind','44 Kinler','Saint Paul','M ','
55116');  
  
INSERT INTO CUSTOMERS VALUES(447,'Borskiy, Jamie','12301 Warner Dr','St. Augusti
ne','FL','32084');
  

INSERT INTO CUSTOMERS VALUES(448,'Larson, Heriberto','7623 Matera St #103','Alpi
ne','AL','35014');
  
INSERT INTO CUSTOMERS VALUES(449,'Chandrasekhar, Yagnaraju','2149 West Dunlap Av
enue','Bethalto','IL','62010');   
  
INSERT INTO CUSTOMERS VALUES(450,'Patthana, Patrick','124 Austin Building','Peor
ia','IL','61614');
  
INSERT INTO CUSTOMERS VALUES(451,'Balija, Jeff','4723. W. Braddock Road','Dallas
','TX','75252');
  
INSERT INTO CUSTOMERS VALUES(452,'Butler, Paul','125 Rosewood Drive','Florence',

'SC','29501');  
  
INSERT INTO CUSTOMERS VALUES(453,'Smith, Uma','915 Sw Harriso','Kc','MO','64151 
   ');  
  
INSERT INTO CUSTOMERS VALUES(454,'Shakeel, Cynthia','120 Blue Ridge Trace','Plai
nsboro','NJ','08536');
  
INSERT INTO CUSTOMERS VALUES(455,'Faver, Michael','260 Franklin Turnpike Apt 513
','Lincol','NE','68512');   
  
INSERT INTO CUSTOMERS VALUES(456,'Ehardt, Faina','4747 Mclane Parkway','Redwood 
City','CA','94062');  

  
INSERT INTO CUSTOMERS VALUES(457,'Hughes, Steve','21555 Oxnard Street','Fento','
MO','63026');   
  
INSERT INTO CUSTOMERS VALUES(458,'Mike, Bill','88 Silva Lane','Berkeley','CA','9
4720');   
  
INSERT INTO CUSTOMERS VALUES(459,'Byker, Samuel','2801 East College Way','Plano'
,'TX','75093'); 
  
INSERT INTO CUSTOMERS VALUES(460,'Weathers, Sandhya','Its - City Hall - Room 6',
'Bowdo','GA','30108');
  

INSERT INTO CUSTOMERS VALUES(461,'Bodnovich, Vivek','1000 Lakeside Dr.','Atlanta
','GA','30339');
  
INSERT INTO CUSTOMERS VALUES(462,'Cofer, Kathy','1441 Schilling Place','Burr Rid
ge','IL','60527');
  
INSERT INTO CUSTOMERS VALUES(463,'Pickens, Bumpy','729 Woodmere Creek Loop','Pit
tsburgh','PA','15233'); 
  
INSERT INTO CUSTOMERS VALUES(464,'Bagent, Tom','1120 N St.','Camp Hill','PA','17
011');
  
INSERT INTO CUSTOMERS VALUES(465,'Sui, Do','6607 Brodis Lane  335','Parsippany',

'NJ','07054');  
  
INSERT INTO CUSTOMERS VALUES(466,'Howard, Harold','920 Harvest Dr','Grand Prairi
e','TX','75050'); 
  
INSERT INTO CUSTOMERS VALUES(467,'Myl, Caroly','4343 Warm Springs Rd Apt 1019','
Butler','PA','16002');
  
INSERT INTO CUSTOMERS VALUES(468,'Ross, Kevi','1955 Amber Trail Rd','Dayto','MD'
,'21036');
  
INSERT INTO CUSTOMERS VALUES(469,'Schmitt, Tom','12001 Sw 14Th Street','Valley F
orge','PA','19482');  

  
INSERT INTO CUSTOMERS VALUES(470,'Thompson, Elsy','916 N. Lincol','Troy','MI','4
8099');   
  
INSERT INTO CUSTOMERS VALUES(471,'Stapleton, Victor','267 Amboy Avenue','Muskego
','MI','49441-4588 ');
  
INSERT INTO CUSTOMERS VALUES(472,'Tallada, Raghu','128 Greenbriar Dr','Madison H
eights','MI','48976');
  
INSERT INTO CUSTOMERS VALUES(473,'Grant, Murali','1344 B Street','Queens Village
','NY','11427');
  

INSERT INTO CUSTOMERS VALUES(474,'Key, David','2 Pierce Place','Streamwood','IL'
,'60107');
  
INSERT INTO CUSTOMERS VALUES(475,'Gupta, Deborah','5 Lilly Pond Circle','Southbo
ro','MA','01772');
  
INSERT INTO CUSTOMERS VALUES(476,'Sharma, Carlo','18081 Midway Rd','Washingto','
DC','20011');   
  
INSERT INTO CUSTOMERS VALUES(477,'Horton, James','2455 Paces Ferry Rd.','William
sville','NY','14221');
  
INSERT INTO CUSTOMERS VALUES(478,'Millard, Dwayne','634 Koehler Road','Seattle',

'WA','98178');  
  
INSERT INTO CUSTOMERS VALUES(479,'Kattekula, Luis','14252 St Rt 65','Eden Prairi
e','M ','55346'); 
  
INSERT INTO CUSTOMERS VALUES(480,'Hanak, Shara','1200 N. Market St.','St. Louis'
,'MO','63113'); 
  
INSERT INTO CUSTOMERS VALUES(481,'Young, Chris','6705 Harlan Drive','Falls Churc
h','VA','22043'); 
  
INSERT INTO CUSTOMERS VALUES(482,'Rampel, Joh','123-12 Gcp','Waco','TX','76710  
  ');   

  
INSERT INTO CUSTOMERS VALUES(483,'Kumar, Gary','183 Loudon Rd, Apt   4','Columbu
s','OH','43201'); 
  
INSERT INTO CUSTOMERS VALUES(484,'Gallaspy, Bill','2794 Blarefield Driev','New Y
ork','NY','10041');   
  
INSERT INTO CUSTOMERS VALUES(485,'Kerr, Harper','Po Box 2337','St Albans','VT','
05478');  
  
INSERT INTO CUSTOMERS VALUES(486,'Rose, Ala','P.O. Box 8553','St. Petersburg','F
L','33704');
  

INSERT INTO CUSTOMERS VALUES(487,'Pak, Robert','101 Satinwood Drive','Mechanicsv
ille','VA','23111');  
  
INSERT INTO CUSTOMERS VALUES(488,'Howland, Robert','5806 Leanne L','Pittsburg','
CA','94565');   
  
INSERT INTO CUSTOMERS VALUES(489,'Kauffmanm, Lashonda','211 Main Street','Saraso
ta','FL','34243');
  
INSERT INTO CUSTOMERS VALUES(490,'Johnson, Balasundaram','850 Cherry','New York'
,'NY','10292'); 
  
INSERT INTO CUSTOMERS VALUES(491,'Grahovek, Stephe','12 Booth Street','Germantow

','T ','38138');
  
INSERT INTO CUSTOMERS VALUES(492,'Brown, Nagarju','Po Box 50','Poughkeepsie','NY
','12603'); 
  
INSERT INTO CUSTOMERS VALUES(493,'Stewart, Christopher','1 Court Circle','George
tow','TX','78628');   
  
INSERT INTO CUSTOMERS VALUES(494,'Barrios, Rajeev','471 Regan L','Northborough',
'MA','01532');  
  
INSERT INTO CUSTOMERS VALUES(495,'Smith, Arthur','P.O. Box 190886','Laurelto','N
Y','11413');

  
INSERT INTO CUSTOMERS VALUES(496,'Conlan, Armstrong','3404 Tulane Drive Apt. 21'
,'Forestville','MD','20747'); 
  
INSERT INTO CUSTOMERS VALUES(497,'Mccord, Alex','1731 Ne 141 St','Schaumburg','I
L','60173');
  
INSERT INTO CUSTOMERS VALUES(498,'Brasher, Ruth','4 S. Highview Cir','Charlotte'
,'NC','28211'); 
  
INSERT INTO CUSTOMERS VALUES(499,'Mayo, Kevi','2882 Tall Oaks Ct','Dayto','OH','
45449');  
  

INSERT INTO CUSTOMERS VALUES(500,'Bivans, Paul','17B Pauline Street','Columbus',
'GA','31909');  
  
INSERT INTO CUSTOMERS VALUES(501,'Korde, Shubha','1326 Mississippi Street','San 
Jose','CA','95134');  
  
INSERT INTO CUSTOMERS VALUES(502,'Mauthe, Hipolito','1262 11Th Avenue','Philadel
phia','PA','19128-4732 ');  
  
INSERT INTO CUSTOMERS VALUES(503,'Woolf, Ginny','16021 N 30Th St Unit 110','Hous
to','TX','77060');
  
INSERT INTO CUSTOMERS VALUES(504,'Richards, Kim','1800 Harrison St, 9Th Fl','Mil

ford','CT','06460');  
  
INSERT INTO CUSTOMERS VALUES(505,'Hacker, Rube','3 Willow Way','Cleveland','OH',
'44115'); 
  
INSERT INTO CUSTOMERS VALUES(506,'Seeley, Joe','1101 Monterey Blvd','Secaucus','
NJ','07094');   
  
INSERT INTO CUSTOMERS VALUES(507,'Dzialak, Francisco','9523 Blake Lane 101','Mes
quite','TX','75181-1266 '); 
  
INSERT INTO CUSTOMERS VALUES(508,'Cassara, Glen','5514 W. Como Ave.','Va','WA','
98654');  

  
INSERT INTO CUSTOMERS VALUES(509,'Bassett, Mark','12750 Fair Lakes Circle','Farm
ingto','CT','06032'); 
  
INSERT INTO CUSTOMERS VALUES(510,'Diggity, Shailesh','7 Easton Oval','Parsippany
','NJ','07054');
  
INSERT INTO CUSTOMERS VALUES(511,'Armalie, Dennis','50 East 21St Street','Salina
s','CA','93907'); 
  
INSERT INTO CUSTOMERS VALUES(512,'Miller, Billy','1123A Kingbolt Circle Dr','Cas
tro Valley','CA','94552');  
  

INSERT INTO CUSTOMERS VALUES(513,'Caldwell, Luminita','170 Big Perry Rd','Midlot
hia','VA','23114');   
  
INSERT INTO CUSTOMERS VALUES(514,'Herrera, Ke','8231 Princeton Sq Blvd','Bridget
o','MO','63044-1785 '); 
  
INSERT INTO CUSTOMERS VALUES(515,'Tucker, Do','25 Abenaki Road','Charlotte','NC'
,'28211');
  
INSERT INTO CUSTOMERS VALUES(516,'Nair, Reggie','4536 Castleton Rd','Glastonbury
','CT','06033');
  
INSERT INTO CUSTOMERS VALUES(517,'Yerrapu, Michele','12892 Glendon Street','Fall

s Church','VA','22043');
  
INSERT INTO CUSTOMERS VALUES(518,'Julien, Gil','59 Clinton St','Countryside','IL
','60525-4088 '); 
  
INSERT INTO CUSTOMERS VALUES(519,'Spencer, Robert','P.O. Box 38136','Newark','NJ
','07106'); 
  
INSERT INTO CUSTOMERS VALUES(520,'Giglio, Ric','319 Krams Avenue','Pembroke Pine
s','FL','33025'); 
  
INSERT INTO CUSTOMERS VALUES(521,'Wheatley, Paul','295 Firstmerit Circle','Alle'
,'TX','75002'); 

  
INSERT INTO CUSTOMERS VALUES(522,'Bommareddy, Richard','4415 Canoga Ave','New Yo
rk','NY','10016-6702 ');
  
INSERT INTO CUSTOMERS VALUES(523,'Vera, Kevi','9379 '''' Street','Aurora','IL','
60504');  
  
INSERT INTO CUSTOMERS VALUES(524,'Rozenberg, Angela','1310, Oakcrest Dr.','Falls
 Church','VA','22043'); 
  
INSERT INTO CUSTOMERS VALUES(525,'Agrawal, Weining','1435 Chrome Hill Road','Chi
ckasha','OK','73018');
  

INSERT INTO CUSTOMERS VALUES(526,'Grottolo, Satya','710 1/2 Stark St.','Manchest
er','CT','06040');
  
INSERT INTO CUSTOMERS VALUES(527,'Malausky, Scott','14000 Hwy 82W','Forest','VA'
,'24551');
  
INSERT INTO CUSTOMERS VALUES(528,'Erdman, Paul','5021 Shinnecock Hills Dr. N.W.'
,'Dallas','TX','75218');
  
INSERT INTO CUSTOMERS VALUES(529,'Soucie, Kimberly','6694 Cottontown Rd','Needha
m','MA','02494'); 
  
INSERT INTO CUSTOMERS VALUES(530,'Lance, Al','Admn 122','Columbia','SC','29223  

  ');   
  
INSERT INTO CUSTOMERS VALUES(531,'Pat, Ed','1601 Bryan St., Suite 27-037','Mclea
','IL','61754-7541 ');
  
INSERT INTO CUSTOMERS VALUES(532,'Brown, Ashwini','821 S Williams','Cullma','AL'
,'35055');
  
INSERT INTO CUSTOMERS VALUES(533,'Krani, George','2014 S 102Nd Street, 210 C','M
aynard','MA','01754');
  
INSERT INTO CUSTOMERS VALUES(534,'Routhu, Mark','476 Viola Rd.','Frankli','T ','
37067');  

  
INSERT INTO CUSTOMERS VALUES(535,'Johnson, Wendy','1223 Cannes Court','Mt Horeb'
,'WI','53572'); 
  
INSERT INTO CUSTOMERS VALUES(536,'Justme, David','57 Cheshire Dr','Jackso','MI',
'49202'); 
  
INSERT INTO CUSTOMERS VALUES(537,'Nevils, William','1200 N. Market St.','Centerv
ille','M ','55038');  
  
INSERT INTO CUSTOMERS VALUES(538,'Mills, Richard','8 Glenford Lane','Jacksonvill
e,','FL','32217-4313 ');
  

INSERT INTO CUSTOMERS VALUES(539,'Antosca, Andrew','485 Duane Terrace','Ann Arbo
r','MI','48108'); 
  
INSERT INTO CUSTOMERS VALUES(540,'Pao, Sidoneo','200 Engamore Lane','Tallahassee
','FL','32315');
  
INSERT INTO CUSTOMERS VALUES(541,'Nolan, Joseph','13 N San Marcos Rd','Camillus'
,'NY','13031'); 
  
INSERT INTO CUSTOMERS VALUES(542,'Otis, Connie','165 Timmons Road','Columbus','I
 ','43231');
  
INSERT INTO CUSTOMERS VALUES(543,'Val, Zarina begum','34-38 71St St','Plano','TX

','75024'); 
  
INSERT INTO CUSTOMERS VALUES(544,'Wright, Venkat','800 Crescent Center Drive, Su
i','Jamaica','NY','11435'); 
  
INSERT INTO CUSTOMERS VALUES(545,'Mullen, Charles','409 Eleventh St.','Parsippan
y','NJ','07054'); 
  
INSERT INTO CUSTOMERS VALUES(546,'Kelly, George','7852 Ponce Ave','Palatine','IL
','60074'); 
  
INSERT INTO CUSTOMERS VALUES(547,'Humble, Je','430 Castle Dr','Woodland Hills','
CA','91364');   

  
INSERT INTO CUSTOMERS VALUES(548,'Rogers, L','P. O.  Box  53167','St. Louis','MO
','63110'); 
  
INSERT INTO CUSTOMERS VALUES(549,'Rivera, Joseph','12033 Foundation Place','Netc
ong','NJ','07857');   
  
INSERT INTO CUSTOMERS VALUES(550,'Nelsen, Jim','4251 Parkalwn Ave, # 202','Ft Wa
shingto','MD','20744'); 
  
INSERT INTO CUSTOMERS VALUES(551,'Wilson, Kenneth','1011 N 26Th','West Des Moine
s','IA','50266'); 
  

INSERT INTO CUSTOMERS VALUES(552,'Jackson, Sukumar','118 Kendrick St.','Tampa','
FL','33607');   
  
INSERT INTO CUSTOMERS VALUES(553,'Pukala, James','35 W59Th Street','Baltimore','
MD','21207');   
  
INSERT INTO CUSTOMERS VALUES(554,'Wen, Wayne','1950 Franklin Street','Vallejo','
CA','94590');   
  
INSERT INTO CUSTOMERS VALUES(555,'Smth, Lana','2567 South 156 Avenue','Warre','P
A','16365');
  
INSERT INTO CUSTOMERS VALUES(556,'Landin, Peggy','3011 Woodloop L','Phoenix','AZ

','85022'); 
  
INSERT INTO CUSTOMERS VALUES(557,'Loest, Monica','14 Locust Grove Road','Lenoir'
,'NC','28645'); 
  
INSERT INTO CUSTOMERS VALUES(558,'Oliveira, Puli','3219 S Grace Ave','Jersey Cit
y','NJ','07302'); 
  
INSERT INTO CUSTOMERS VALUES(559,'Bohra, Mark','Brgy. 68, San Francisco,','Succa
sunna','NJ','07876'); 
  
INSERT INTO CUSTOMERS VALUES(560,'Varner, Sangil','940 W 131St St','Legaspi City
','PR','04500');

  
INSERT INTO CUSTOMERS VALUES(561,'Reinhart, Terry','East Hall, Room 7','Toronto'
,'T ','37415'); 
  
INSERT INTO CUSTOMERS VALUES(562,'Kidwell, Suresh','4005 Brookhaven Club Drive',
'Housto','TX','77269-2370 '); 
  
INSERT INTO CUSTOMERS VALUES(563,'Hogen, Fausitna','315 Bart Rd.','Leominster','
MA','01453');   
  
INSERT INTO CUSTOMERS VALUES(564,'Tamunday, D','1409,Roper Mountain Road, Apt','
Hopatcong','NJ','07843');   
  

INSERT INTO CUSTOMERS VALUES(565,'Hunter, Deepa','1951 Cypress Street','Columbia
','SC','29201');
  
INSERT INTO CUSTOMERS VALUES(566,'Fuglemsmo, Johny','3543 Simpson Ferry Rd','Tay
lor Mill','AK','78 ');
  
INSERT INTO CUSTOMERS VALUES(567,'Schaa, Greg','821 Azores Cir','Austi','TX','78
704');
  
INSERT INTO CUSTOMERS VALUES(568,'Oakes, Tyrone','2383 Akers Mill Road','Columbu
s','OH','43220'); 
  
INSERT INTO CUSTOMERS VALUES(569,'Bingham, Robert','44 Boulder Avenue','Birmingh

am','AL','35215');
  
INSERT INTO CUSTOMERS VALUES(570,'Paik, Bria','2000 Westminster Lane','Rochester
 Hills','MI','48307');
  
INSERT INTO CUSTOMERS VALUES(571,'Smith, Lloyd','9432 Downing Circle','Pullma','
WA','99164');   
  
INSERT INTO CUSTOMERS VALUES(572,'Torres, Peter','1102 North 8Th Street','Westmi
nster','CO','80021'); 
  
INSERT INTO CUSTOMERS VALUES(573,'Hayes, Da','P.O. Box 777','Brookly','NY','1123
5');

  
INSERT INTO CUSTOMERS VALUES(574,'Jackson, Laura','3570- C, Meadowglenn Apts','L
e Mars','IA','51031');
  
INSERT INTO CUSTOMERS VALUES(575,'Shepherd, Jamie','1341 East Thacker Street','H
ighlands Ranch','CO','80126');
  
INSERT INTO CUSTOMERS VALUES(576,'Pluff, Mark','9420 Key West Avenue','Springfie
ld','NJ','07081');
  
INSERT INTO CUSTOMERS VALUES(577,'Cefalu, George','19 Winchester St #207','Milwa
ukee','WI','53212');  
  

INSERT INTO CUSTOMERS VALUES(578,'Hines, Enoch','2416 Westgate Dr','Dallas','TX'
,'75201');
  
INSERT INTO CUSTOMERS VALUES(579,'Swartz, Doug','405 Pattoon St','Irving','TX','
75039');  
  
INSERT INTO CUSTOMERS VALUES(580,'Mccann, Chris','Po Box 9041','Omaha','NE','681
27'); 
  
INSERT INTO CUSTOMERS VALUES(581,'Wilder, Phil','210 W. Collins','Berkeley','CA'
,'94720');
  
INSERT INTO CUSTOMERS VALUES(582,'Denny, Scott','707 East Central','Oak Park','I

L','60301');
  
INSERT INTO CUSTOMERS VALUES(583,'Brethauer, Rhonda','108 Copperfield Road','St 
Louis','MO','63101'); 
  
INSERT INTO CUSTOMERS VALUES(584,'Heng, Xiaowei','800 South Washington Street','
Clarks Summit','PA','18411'); 
  
INSERT INTO CUSTOMERS VALUES(585,'Vulman, George','340 West Miller Street','West
minster','CO','80030'); 
  
INSERT INTO CUSTOMERS VALUES(586,'Miller, Roby','3527 Holmead Pl.','Saint Louis'
,'MO','63136'); 

  
INSERT INTO CUSTOMERS VALUES(587,'Ibach, Ray','43155 Wayne Stevens Rd','Pompton 
Plains','NJ','07444');
  
INSERT INTO CUSTOMERS VALUES(588,'Hubbard, Jill','128 Pine Hill Avenue','Falls C
hurch','VA','22043'); 
  
INSERT INTO CUSTOMERS VALUES(589,'Peterson, Arthur','2682 Southmoore Cove','Atla
tna','GA','30328');   
  
INSERT INTO CUSTOMERS VALUES(590,'Blow, Raj','3100 Expressway Apt. 652','Livonia
','MI','48150');
  

INSERT INTO CUSTOMERS VALUES(591,'Maltais, Sheri','3533 Lee Hills Dr.','Wyoming'
,'MI','49509'); 
  
INSERT INTO CUSTOMERS VALUES(592,'Reeves, Raleigh','15 Forest Street','Eden Prai
rie','M ','55344');   
  
INSERT INTO CUSTOMERS VALUES(593,'Chavan, Rhonda','518 Commanche Tr.','Greensbor
o','NC','27410'); 
  
INSERT INTO CUSTOMERS VALUES(594,'Pineda, Bhargava','1146-A Easton Ave','Olive B
ranch','MS','38654'); 
  
INSERT INTO CUSTOMERS VALUES(595,'Mcmillen, G','Po Box 459','Kirkland','WA','980

33'); 
  
INSERT INTO CUSTOMERS VALUES(596,'Hanna, Andrew','43 Railroad Av','Springboro','
OH','45066');   
  
INSERT INTO CUSTOMERS VALUES(597,'Foreman, Louis','138-45 224Th Street','Springf
ield','MO','65804');  
  
INSERT INTO CUSTOMERS VALUES(598,'Bentley, Kieu','1248 N 119Th St','Chicago','IL
','60606'); 
  
INSERT INTO CUSTOMERS VALUES(599,'Ahmed, Uma','110 Jay Dr.','Polk City','IA','50
226');

  
INSERT INTO CUSTOMERS VALUES(600,'Anderson, Randy','811 Polo Road','Wilmerding',
'PA','15148');  
  
INSERT INTO CUSTOMERS VALUES(601,'Harrison, Will','100 Half Day Rd.','East Bruns
wik','NJ','08816');   
  
INSERT INTO CUSTOMERS VALUES(602,'Lind, Bryo','219 Grenadier Drive','Safety Harb
or','FL','34695');
  
INSERT INTO CUSTOMERS VALUES(603,'Guzman, Robert','194 Crofton Drive','Evans','G
A','30809');
  

INSERT INTO CUSTOMERS VALUES(604,'Bathwater, Venkatesh','605 Suwannee St.','Burl
ingame','CA','94010');
  
INSERT INTO CUSTOMERS VALUES(605,'Hester, Robert','1 Constitution Way','Baltimor
e','MD','21244'); 
  
INSERT INTO CUSTOMERS VALUES(606,'Gross, Ranji','26 Mist Hill Drive','Madiso','S
D','57042');
  
INSERT INTO CUSTOMERS VALUES(607,'Mukhopadhyay, Kondal rao','43 Huntington St','
Herndo','VA','20170');
  
INSERT INTO CUSTOMERS VALUES(608,'Ranieri, Rich','118 Huntington Street','Housto

','TX','77096');
  
INSERT INTO CUSTOMERS VALUES(609,'Young, James','6368 Andrews Dr W','Buffalo','N
Y','14203');
  
INSERT INTO CUSTOMERS VALUES(610,'Coleman, Carl','30 S. Wacker Dr','Dallas','TX'
,'75248');
  
INSERT INTO CUSTOMERS VALUES(611,'Avula, Glen','650 South Front St.','Matthews',
'NC','28104');  
  
INSERT INTO CUSTOMERS VALUES(612,'Chen, Mary','22 Pleasant Street','Baltimore','
MD','21214');   

  
INSERT INTO CUSTOMERS VALUES(613,'Hinkley, Martha','2111 E. 37Th St. N.','Woodla
nd Hills','CA','91367');
  
INSERT INTO CUSTOMERS VALUES(614,'Matte, Kris','1225 Nw Cooke Ave','Austi','TX',
'78148'); 
  
INSERT INTO CUSTOMERS VALUES(615,'Galvis, Mike','4015 Buckingham Road','Alexandr
ia','VA','22311');
  
INSERT INTO CUSTOMERS VALUES(616,'Dennis, Larry','900 Mickley Rd','Lafayette','L
A','70506');
  

INSERT INTO CUSTOMERS VALUES(617,'Murray, Teresa','1200 Corporate Systems Center
','St. Louis','MO','63103');
  
INSERT INTO CUSTOMERS VALUES(618,'Prakash, Richie','26 Corporate Hill Dr.','Carm
ichael','CA','95608');
  
INSERT INTO CUSTOMERS VALUES(619,'Buntin, Ravikumar','5087 Sheridan Dr.','Grand 
Forks','ND','58201'); 
  
INSERT INTO CUSTOMERS VALUES(620,'Rehm, Robert','1900 E. Oakland St.','Cedar Fal
ls','IA','50613');
  
INSERT INTO CUSTOMERS VALUES(621,'Sherman, Steve','1800 Longcreek Dr.','Berwy','

IL','60402');   
  
INSERT INTO CUSTOMERS VALUES(622,'Bryant, Shilpa','21 Meadow Rd.','Auburn Hills'
,'MI','48326'); 
  
INSERT INTO CUSTOMERS VALUES(623,'Miranda, Bob','154 Apt # H','Carmel','I ','460
32'); 
  
INSERT INTO CUSTOMERS VALUES(624,'Giragani, Michelle','2335 Saint Albans Place',
'North Wales','PA','19454');
  
INSERT INTO CUSTOMERS VALUES(625,'Aronov, Mark','1000 Cherry Lane','Mesa','PA','
85310');  

  
INSERT INTO CUSTOMERS VALUES(626,'Anto, Joh','3500 Savannah Park Ln.','Alpharett
a','GA','30022'); 
  
INSERT INTO CUSTOMERS VALUES(627,'Mavraedis, Charles','1-205 Lamoine Village','C
ypress','TX','77429');
  
INSERT INTO CUSTOMERS VALUES(628,'Tankkar, Boris','1049 Creek Hollow Lane','Alba
ny','NY','12203');
  
INSERT INTO CUSTOMERS VALUES(629,'Blick, Mark','1335 Bradyville Pike Apt F206','
Hopkins','M ','55343'); 
  

INSERT INTO CUSTOMERS VALUES(630,'Mansir, Theresa','312 Bishop Rd','Greenvile','
SC','29615');   
  
INSERT INTO CUSTOMERS VALUES(631,'Yang, Daniel','343 Peach Rd','Queens','NY','11
362');
  
INSERT INTO CUSTOMERS VALUES(632,'Phillips, Louis','90-19 211Th Street','Salisbu
ry','MD','21802');
  
INSERT INTO CUSTOMERS VALUES(633,'Fannin, P.','5000 Ellin Rd','Mitchellville','M
D','20721');
  
INSERT INTO CUSTOMERS VALUES(634,'Kondratieff, Bill','P.O.Box 245','Omaha','NE',

'68103-0777 '); 
  
INSERT INTO CUSTOMERS VALUES(635,'May, Joan','Po Box 645910','Starkville','MS','
39759');  
  
INSERT INTO CUSTOMERS VALUES(636,'Wainscott, Brent','1129 Treeside L','Mahwah','
NJ','07430');   
  
INSERT INTO CUSTOMERS VALUES(637,'Akkiraju, Mike','3811 N. Bell','Hazlet','NJ','
07730');  
  
INSERT INTO CUSTOMERS VALUES(638,'Davis, Frank','2222 Welborn St.','Milwaukee','
WI','53202');   

  
INSERT INTO CUSTOMERS VALUES(639,'Zaslavskaya, Alok','2850 24Th Avenue','Haciend
a Heights','CA','91745');   
  
INSERT INTO CUSTOMERS VALUES(640,'Burgess, Jonatha','5909 Birchbrook','Grand Pra
irie','TX','75050');  
  
INSERT INTO CUSTOMERS VALUES(641,'Hall, Wayne','6 Reservoir Drive','Columbia','T
 ','38401');
  
INSERT INTO CUSTOMERS VALUES(642,'Lee, Cindy','1000 Middle St','Flushing','NY','
11354');  
  

INSERT INTO CUSTOMERS VALUES(643,'Grimm, jr., Ramanatha','20 Bernard Road','Barr
ingto','IL','60010'); 
  
INSERT INTO CUSTOMERS VALUES(644,'Cable, Clay','1463 Timber Ridge Court','Gilber
t','AZ','85233'); 
  
INSERT INTO CUSTOMERS VALUES(645,'Alderman, James','6405 N Mokane Ct','Columbia'
,'MD','21046'); 
  
INSERT INTO CUSTOMERS VALUES(646,'Ivy, Erika','10433 Sunnybrook Circle','Baltimo
re','MD','21207');
  
INSERT INTO CUSTOMERS VALUES(647,'Kota, Connie','400 Sir Walter Drive','Willingb

oro','NJ','08046');   
  
INSERT INTO CUSTOMERS VALUES(648,'Deb, Pio','3855 Blair Mill Rd','Mentor','OH','
44060');  
  
INSERT INTO CUSTOMERS VALUES(649,'Salazar, Joel','1601 1St Ave.','El Segundo','C
A','90245-3803 ');
  
INSERT INTO CUSTOMERS VALUES(650,'Lynn, Nelso','1945 Lindenwood','Brookly','NY',
'11219'); 
  
INSERT INTO CUSTOMERS VALUES(651,'Dunn, Ole','317 Main Street - Info Sys','Birmi
ngham','AL','35288'); 

  
INSERT INTO CUSTOMERS VALUES(652,'Meadows, Joy','1429 Senate Street','Sacramento
','CA','95818');
  
INSERT INTO CUSTOMERS VALUES(653,'Milliano, Chuan hwa','2150 Wenlok Trail','Chic
ago','IL','60615');   
  
INSERT INTO CUSTOMERS VALUES(654,'Kamble, Keith','27473 Audrey','Carrollto','TX'
,'75006');
  
INSERT INTO CUSTOMERS VALUES(655,'Lee, Valerie','1381 Anderson Avenue','Sacramen
to','CA','95814');
  

INSERT INTO CUSTOMERS VALUES(656,'Jachimski, Myro','8000 Utopia','Glendale','AZ'
,'85302');
  
INSERT INTO CUSTOMERS VALUES(657,'Zavrotny, Lisa','4905 Muirwood Dr','Glen Alle'
,'VA','23030'); 
  
INSERT INTO CUSTOMERS VALUES(658,'Lee, Jeff','32 Gatehouse Lane','Roseville','CA
','95829'); 
  
INSERT INTO CUSTOMERS VALUES(659,'Weckbecker, Asoka','4556 Shadowridge Dr','Cinc
innati','OH','45238');
  
INSERT INTO CUSTOMERS VALUES(660,'Ritzcovan, Toocee','2828 Tudor Court','West Al

lis','WI','53227');   
  
INSERT INTO CUSTOMERS VALUES(661,'Chogyoji, Rahul','2100 Nursery Rd Apt E1','Whi
tehall','PA','18052');
  
INSERT INTO CUSTOMERS VALUES(662,'Vengala, Kim','110 Kope Ave','Oklahoma City','
OK','73112');   
  
INSERT INTO CUSTOMERS VALUES(663,'Turnquist, Sharo','1222 N. Fieldcrest St.','St
ephenville','TX','76401');  
  
INSERT INTO CUSTOMERS VALUES(664,'Rodriguez, Earlene','537 Mansfield Village','J
ackso','MS','39217'); 

  
INSERT INTO CUSTOMERS VALUES(665,'Wu, Jeffrey','4800 Regent Blvd','Como','TX','7
5431');   
  
INSERT INTO CUSTOMERS VALUES(666,'Amoroso, Hazel-an','5114 Walnut Haven L','Tall
ahassee','FL','32362'); 
  
INSERT INTO CUSTOMERS VALUES(667,'Keeble, Joh','71 Hanover Rd','Louisville','KY'
,'43215');
  
INSERT INTO CUSTOMERS VALUES(668,'Bozonelos, Pulkit','3330 N. Causeway Blvd.','L
as Vegas','NV','89117');
  

INSERT INTO CUSTOMERS VALUES(669,'Cadle, Michael','572 Brook Street','Van Wert',
'OH','45891');  
  
INSERT INTO CUSTOMERS VALUES(670,'Patel, Ramesh','194 Wood Ave, South','San Dieg
o','CA','92126'); 
  
INSERT INTO CUSTOMERS VALUES(671,'Slivkoff, Scott','P.O. Box 524','Summerville',
'SC','29483');  
  
INSERT INTO CUSTOMERS VALUES(672,'Krish, Munish','451 N. Lake Ave.','Cedar Rapid
s','IA','52404'); 
  
INSERT INTO CUSTOMERS VALUES(673,'Arumugam, Hemant','4075, Pineset Drive','Dalla

s','TX','75132'); 
  
INSERT INTO CUSTOMERS VALUES(674,'Franklin, Cesar','5260 Winchester Road','Schau
mburg','IL','60173'); 
  
INSERT INTO CUSTOMERS VALUES(675,'Nguyen, Ram','1006 Gardens Place','Decatur','G
A','30030');
  
INSERT INTO CUSTOMERS VALUES(676,'Carroll, Sam','9379 N Street','Long Beach','CA
','90806'); 
  
INSERT INTO CUSTOMERS VALUES(677,'Shaw, Warre','1741 E. Robin Lane','Washingto',
'DC','20002');  

  
INSERT INTO CUSTOMERS VALUES(678,'Powell, Tony','128 Westridge Dr','Latham','NY'
,'12110');
  
INSERT INTO CUSTOMERS VALUES(679,'Warner, Bala','Po Box 335','West Hartford','CT
','06119'); 
  
INSERT INTO CUSTOMERS VALUES(680,'Vera, Anbusekara','526 Hunterdale Road','Colum
bus','OH','43231');   
  
INSERT INTO CUSTOMERS VALUES(681,'Oneil, Ri','7961 Inwood L','Olympia','WA','985
04-3123 '); 
  

INSERT INTO CUSTOMERS VALUES(682,'Condron, Michael','866 Butternut Dr.','Salinas
','CA','93901');
  
INSERT INTO CUSTOMERS VALUES(683,'Yu, Hemant','19621 Portsmouth Drive','Lanham',
'MD','20706');  
  
INSERT INTO CUSTOMERS VALUES(684,'Dutton, Philip','225 Summit Avenue','Dacula','
GA','30019');   
  
INSERT INTO CUSTOMERS VALUES(685,'Kumar, Manoj','756 Crocus Lane','Charlotte','N
C','28269');
  
INSERT INTO CUSTOMERS VALUES(686,'Wolff, Ke','820 Club Chase Ct.','Ediso','NJ','

08837');  
  
INSERT INTO CUSTOMERS VALUES(687,'Collier, Da','7212 Dalewood Dr.','Duluth','GA'
,'30097');
  
INSERT INTO CUSTOMERS VALUES(688,'Jerome, Beverly','3206 Greenhollow Dr','Metuch
e','NJ','08840'); 
  
INSERT INTO CUSTOMERS VALUES(689,'Leonnig, Timothy','1802 Bel Air Dr','Columbus'
,'OH','43229'); 
  
INSERT INTO CUSTOMERS VALUES(690,'Mceachen, Art','4204 Greencastle Ct.  102','Sp
ring','TX','77373');  

  
INSERT INTO CUSTOMERS VALUES(691,'Czarnik, Mark','480 Valley Rd., A15','Mankato'
,'M ','56001'); 
  
INSERT INTO CUSTOMERS VALUES(692,'Lowe, Doug','3251 W. Ellery','Fresno','CA','93
711');
  
INSERT INTO CUSTOMERS VALUES(693,'Smith, Lawrence','2883 Sicamore Street','Fresn
o','CA','93711'); 
  
INSERT INTO CUSTOMERS VALUES(694,'Wilson, Wilso','4288 Maple','Fresno','CA','937
11'); 
  

INSERT INTO CUSTOMERS VALUES(695,'Blake, Joh','388 Sicamore','Fresno','CA','9370
4');
  
INSERT INTO CUSTOMERS VALUES(696,'Wilkins, Adria','488 Maple','Fresno','CA','92707 '); 
  
INSERT INTO CUSTOMERS VALUES(722,'Luis Gonzales','Ambato','Ambato','AK','56709   ');   
  
INSERT INTO CUSTOMERS VALUES(701,'Emerson','Ambato','Ambato','XE','89 ');   
  
INSERT INTO CUSTOMERS VALUES(723,'Humberto Caicedo','San Francisco','New','VA','3567 ');  
  
INSERT INTO CUSTOMERS VALUES(724,'Alberto Spencer','Hambur','New','HI','2340');
  

