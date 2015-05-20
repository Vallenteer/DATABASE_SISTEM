#script persiapan
#membuat table mahasiswa
create table `db_tugas2`.`Mahasiswa`(
`NIM` INT NOT NULL AUTO_INCREMENT,
`Nama_Mahasiswa` VARCHAR(20) NOT NULL,
`Email` varchar(45) NULL,
`JenisKelamin` ENUM('M','F') NULL,
`alamat` TEXT NULL,
`Tahun_Masuk` year null,
PRIMARY KEY (`NIM`),
UNIQUE INDEX `nip_UNIQUE` (`NIM` ASC));

#membuat table MataKuliah
create table `db_tugas2`.`MataKuliah`(
`KodeMK` Varchar(9) Not Null,
`NamaMK` VARCHAR(20) NOT NULL,
`SKS` INT NULL,
PRIMARY KEY (`KodeMK`),
UNIQUE INDEX `nip_UNIQUE` (`KodeMK` ASC));

#Membuat table tablekuliah
create table `db_tugas2`.`tablekuliah`(
`No` int NOT NULL AUTO_INCREMENT,
`NIM` INT null,
`Semester` INT NULL,
`KodeMK` Varchar(9) Not Null,
`Nilai_Huruf` varchar(3) null,
`Nilai_Angka` float4 NULL,
`nilaiIP` float4 NULL,
`totalnilaiip` float4 NULL,
UNIQUE INDEX `nip_UNIQUE` (`No` ASC));


#membuat table ip
create table `db_tugas2`.`IP`(
`NIM` INT NOT NULL AUTO_INCREMENT,
`IP_Awal` float4 NULL,
UNIQUE INDEX `nip_UNIQUE` (`NIM` ASC));

#membuat table ip_kon ( untuk konversi dari 4 ke 5)
create table `db_tugas2`.`IP_KON`(
`NIM` INT NOT NULL AUTO_INCREMENT,
`IP_Awal` float4 NULL,
`IP_Konversi` float4 NULL,
UNIQUE INDEX `nip_UNIQUE` (`NIM` ASC));



#insert data di table mahasiswa berupa nama,semester,jeniskelamin, NIM(otomatis)
insert into Mahasiswa (Nama_Mahasiswa,JenisKelamin)
value ('Yulanda Puga',	'F'),
('Antony Lacasse',	'M'),
('Glory Twiss',	'F'),
('Francesca Violette',	'F'),
('Milo Lehoux',	'M'),
('Era Legette',	'F'),
('Demetria Cheng',	'F'),
('Nila Downing',	'F'),
('Cory Havens',	'M'),
('Edwin Tidd',	'M'),
('Mark Strackbein',	'M'),
('Allyn Corson',	'F'),
('Angeline Crozier',	'F'),
('Lourdes Dubreuil',	'F'),
('Ava Madson',	'F'),
('Lizzette Jacob',	'F'),
('Traci Sitz',	'F'),
('Inocencia Corbett',	'F'),
('Vicky Marnell',	'F'),
('Tabatha Armstrong',	'F'),
('Darcel Cullum',	'F'),
('Lanie Gatlin',	'F'),
('Alvera Verdi',	'F'),
('Kathaleen Maese',	'F'),
('Jaimie Basco',	'F'),
('Myrtice Whitehill',	'F'),
('Lang Laing',	'F'),
('Brenton Gumm',	'M'),
('Sheilah Steinke',	'F'),
('Claudette Mickles',	'F'),
('Erminia Claeys',	'F'),
('Racquel Bissett',	'F'),
('Larita Scurlock',	'F'),
('Tod Brauer',	'M'),
('Merideth Hartt',	'F'),
('Parker Mackay',	'M'),
('Leonarda Trickey',	'F'),
('Madge Rippeon',	'F'),
('Margherita Merlo',	'F'),
('Julianne Beem',	'F'),
('Lanette Hogan',	'F'),
('Greg Fraire',	'M'),
('Wava Hazley',	'F'),
('Precious Mandell',	'F'),
('Rolf Dusenberry',	'M'),
('Irma Kangas',	'F'),
('Janette Rowan',	'F'),
('Milissa Raymer',	'F'),
('Emilio Lambright',	'M'),
('Kyla Buchman',	'F');

#insert data Matakuliah
INSERT INTO `db_tugas2`.`matakuliah` (`KodeMK`, `NamaMK`, `SKS`, `semester`)
 VALUES ('ENG0001', 'English', '2', '1'),
 ('FIS0001', 'Fisika', '3', '1'),
 ('MAT0001', 'Kalkulus', '2', '1');
 
#insert data table kuliah
INSERT INTO `db_tugas2`.`tablekuliah` (`Nilai_Angka`, `NIM`, `KodeMK`)
 VALUES ('59,31946941','1','MAT0001'),
('65,57391668','2','MAT0001'),
('85,85780051','3','MAT0001'),
('78,69975335','4','MAT0001'),
('47,47521301','5','MAT0001'),
('53,87665164','6','MAT0001'),
('94,65324049','7','MAT0001'),
('73,07641392','8','MAT0001'),
('64,18520165','9','MAT0001'),
('46,60859077','10','MAT0001'),
('82,8534499','11','MAT0001'),
('53,38837785','12','MAT0001'),
('64,52404181','13','MAT0001'),
('45,1065843','14','MAT0001'),
('82,99075052','15','MAT0001'),
('56,70771903','16','MAT0001'),
('66,65340298','17','MAT0001'),
('74,93948243','18','MAT0001'),
('90,78370942','19','MAT0001'),
('94,50071959','20','MAT0001'),
('50,79751487','21','MAT0001'),
('66,84609399','22','MAT0001'),
('63,26748402','23','MAT0001'),
('80,80443251','24','MAT0001'),
('71,11297003','25','MAT0001'),
('96,29129015','26','MAT0001'),
('95,97832809','27','MAT0001'),
('64,75248293','28','MAT0001'),
('81,7490119','29','MAT0001'),
('47,59084755','30','MAT0001'),
('81,95117237','31','MAT0001'),
('42,23905891','32','MAT0001'),
('76,86421261','33','MAT0001'),
('90,28890157','34','MAT0001'),
('88,52588935','35','MAT0001'),
('90,28203226','36','MAT0001'),
('80,12542214','37','MAT0001'),
('74,90705303','38','MAT0001'),
('81,14635433','39','MAT0001'),
('92,93181193','40','MAT0001'),
('96,01528972','41','MAT0001'),
('85,73351047','42','MAT0001'),
('41,87212283','43','MAT0001'),
('51,22365794','44','MAT0001'),
('89,40786609','45','MAT0001'),
('47,43963135','46','MAT0001'),
('62,00255483','47','MAT0001'),
('67,05854206','48','MAT0001'),
('56,14507972','49','MAT0001'),
('69,88654711','50','MAT0001'),
('80,50693477','1','FIS0001'),
('81,07078786','2','FIS0001'),
('81,49383705','3','FIS0001'),
('83,66021253','4','FIS0001'),
('56,42679276','5','FIS0001'),
('40,7157679','6','FIS0001'),
('77,35313039','7','FIS0001'),
('57,54194833','8','FIS0001'),
('59,59105967','9','FIS0001'),
('72,24088533','10','FIS0001'),
('92,74782367','11','FIS0001'),
('90,44213399','12','FIS0001'),
('43,02501947','13','FIS0001'),
('61,85725502','14','FIS0001'),
('97,27146171','15','FIS0001'),
('53,07125','16','FIS0001'),
('66,34312007','17','FIS0001'),
('79,21754042','18','FIS0001'),
('41,60016163','19','FIS0001'),
('64,84631662','20','FIS0001'),
('58,23858388','21','FIS0001'),
('65,8024393','22','FIS0001'),
('50,5240742','23','FIS0001'),
('50,88559997','24','FIS0001'),
('48,02696292','25','FIS0001'),
('74,75507492','26','FIS0001'),
('40,64095205','27','FIS0001'),
('97,88225941','28','FIS0001'),
('42,96415681','29','FIS0001'),
('91,90793941','30','FIS0001'),
('95,48679728','31','FIS0001'),
('78,40988945','32','FIS0001'),
('96,73687373','33','FIS0001'),
('96,92303267','34','FIS0001'),
('59,73428831','35','FIS0001'),
('76,83843588','36','FIS0001'),
('62,28523626','37','FIS0001'),
('53,71184599','38','FIS0001'),
('62,39577761','39','FIS0001'),
('63,91962249','40','FIS0001'),
('74,60495808','41','FIS0001'),
('92,99157532','42','FIS0001'),
('78,65224863','43','FIS0001'),
('84,34799056','44','FIS0001'),
('82,49786458','45','FIS0001'),
('60,47654627','46','FIS0001'),
('74,07908949','47','FIS0001'),
('89,98623671','48','FIS0001'),
('98,29337261','49','FIS0001'),
('92,65162556','50','FIS0001'),
('61,80843337','1','ENG0001'),
('69,22610299','2','ENG0001'),
('74,67690794','3','ENG0001'),
('99,57531601','4','ENG0001'),
('73,01489457','5','ENG0001'),
('54,67153768','6','ENG0001'),
('85,01756242','7','ENG0001'),
('58,0556053','8','ENG0001'),
('75,85954033','9','ENG0001'),
('41,95363943','10','ENG0001'),
('86,57315142','11','ENG0001'),
('89,80939946','12','ENG0001'),
('58,63970886','13','ENG0001'),
('58,05747552','14','ENG0001'),
('60,80675846','15','ENG0001'),
('79,39681503','16','ENG0001'),
('90,94099698','17','ENG0001'),
('68,88481205','18','ENG0001'),
('70,26884922','19','ENG0001'),
('54,23882209','20','ENG0001'),
('89,40504543','21','ENG0001'),
('42,02525004','22','ENG0001'),
('89,40425874','23','ENG0001'),
('68,17663127','24','ENG0001'),
('80,51009346','25','ENG0001'),
('79,78973125','26','ENG0001'),
('55,69496797','27','ENG0001'),
('64,79355268','28','ENG0001'),
('43,33251232','29','ENG0001'),
('95,87610766','30','ENG0001'),
('63,71576786','31','ENG0001'),
('70,63963361','32','ENG0001'),
('85,94409835','33','ENG0001'),
('69,59598207','34','ENG0001'),
('92,73326915','35','ENG0001'),
('58,51191541','36','ENG0001'),
('80,08561536','37','ENG0001'),
('86,8794391','38','ENG0001'),
('64,40536933','39','ENG0001'),
('50,14231178','40','ENG0001'),
('78,10875716','41','ENG0001'),
('44,6881051','42','ENG0001'),
('87,99723814','43','ENG0001'),
('66,35985507','44','ENG0001'),
('67,54433712','45','ENG0001'),
('78,34283423','46','ENG0001'),
('66,35852757','47','ENG0001'),
('91,24300001','48','ENG0001'),
('52,54052197','49','ENG0001'),
('77,81884257','50','ENG0001');
#Update semester 
UPDATE tablekuliah
SET semester='1'
WHERE semester<'1';



