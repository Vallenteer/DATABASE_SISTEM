#script pengerjaan
#buat FK (dalam hal ini saya memakai GUI sehingga tidak ada script)
#update tablekuliah.Nilai_Huruf,NilaiIP,totalnilaiip
#Nilai_Huruf
Update tablekuliah
set Nilai_Huruf='A'
where Nilai_Angka>='86';
Update tablekuliah
set Nilai_Huruf='B'
where Nilai_Angka>='71'&& Nilai_Angka<'86';
Update tablekuliah
set Nilai_Huruf='C'
where Nilai_Angka>='60'&& Nilai_Angka<'71';
Update tablekuliah
set Nilai_Huruf='D'
where Nilai_Angka<'60';
#nilaiIP
Update tablekuliah
set nilaiIP='4'
where Nilai_Huruf='A';
Update tablekuliah
set nilaiIP='3'
where Nilai_Huruf='B';
Update tablekuliah
set nilaiIP='2'
where Nilai_Huruf='C';
Update tablekuliah
set nilaiIP='1'
where Nilai_Huruf='D';
#totalnilaiip
Update tablekuliah, matakuliah
set tablekuliah.totalnilaiip=tablekuliah.nilaiIP*matakuliah.SKS
where tablekuliah.KodeMK=matakuliah.KodeMK;


#########pengerjaansoal
#soal no 1
insert into ip (NIM,IP)
SELECT tk.NIM,sum(tk.totalnilaiip / (select sum(SKS) as totalSKS
    FROM matakuliah
	where semester = 1)) as IP
FROM   tablekuliah tk
group by tk.NIM;

#soal no 2 NB: ada ip tertinggi dan ip rata2
select max(ip.ip) as IP_Tertinggi,avg(ip.ip) as rataIP
from ip;

#soal no 3
select avg(ip.IP) as Rata_rata_Mahasiswa
from mahasiswa m natural join ip
where m.JenisKelamin='M';

#soal no 4
select avg(ip.IP) as Rata_rata_Mahasiswi
from mahasiswa m natural join ip
where m.JenisKelamin='F';

#soal no 5
select tk.KodeMK, avg(tk.Nilai_Angka) as Rata_Rata
from tablekuliah tk
group by tk.KodeMK;

#soal no 6
select ip.NIM,m.Nama_Mahasiswa,m.JenisKelamin,ip.ip
from ip natural join mahasiswa m
 order by ip.ip desc
 limit 10;  

#soal no 7
select ip.NIM,m.Nama_Mahasiswa,m.JenisKelamin,ip.ip
from ip natural join mahasiswa m
 order by ip.ip
 limit 10;  
 
#soal no 8
select tk.NIM,m.Nama_Mahasiswa,mk.NamaMK
from tablekuliah tk natural join Mahasiswa m natural join matakuliah mk
where tk.Nilai_Angka<'60';

#soal no 9
select tk.KodeMK,Nilai_Huruf, count(Nilai_Huruf)
from tablekuliah tk
group by KodeMK, Nilai_Huruf;

#soal no 10
insert into ip_kon (NIM,IP_Awal,IP_Konversi)
SELECT ip.NIM,ip.IP,((ip.ip/'4')*'5')
FROM ip;





