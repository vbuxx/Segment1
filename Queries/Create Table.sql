CREATE TABLE Karyawan (
id int IDENTITY(1,1) PRIMARY KEY,
nama varchar(50) NOT NULL,
departemen varchar(50)  NOT NULL,
email varchar(50) NOT NULL UNIQUE,
phone varchar(50) NOT NULL UNIQUE
);

CREATE TABLE Aset (
id int IDENTITY(1,1) PRIMARY KEY,
nama_aset varchar(50) NOT NULL UNIQUE,
detail_aset varchar(50)
);

DROP TABLE Inventaris_Aset, Peminjaman_Aset; 

CREATE TABLE Peminjaman_Aset(
id int IDENTITY(1,1) PRIMARY KEY,
unique_key varchar(50) NOT NULL UNIQUE,
aset_id int,
karyawan_id int,
tgl_keluar date NOT NULL,
tgl_kembali date,
CONSTRAINT FK_Aset FOREIGN KEY (aset_id)
REFERENCES Aset(id),
CONSTRAINT FK_Karyawan FOREIGN KEY (karyawan_id)
REFERENCES Karyawan(id),
);


CREATE TABLE Inventaris_Aset(
aset_id int FOREIGN KEY REFERENCES Aset(id)
CONSTRAINT PK_InventarisAset PRIMARY KEY (aset_id),
tgl_update datetime NOT NULL,
stock_awal int NOT NULL,
stock_sekarang int NOT NULL,
);
