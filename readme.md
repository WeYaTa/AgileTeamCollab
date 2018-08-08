Mata Kuliah : Team Collaboration Tools & Agile Software Development

Nama Anggota :
1. Wesley Yando Tantra (03082170008)
2. Vincent (03082170002)
3. Martin (03082170001)

Nama Project : AgileTeamCollab (Kasir mini)

Notes :
Sebelum menjalankan program di Visual Studio, attach terlebih dahulu Database yang bernama DBAgileTeamCollab pada salah satu engine database milik anda. (melalui SSMS)
Pada bagian Solution Explorer cari project bernama 'AgileTeamCollabLibrary'.
Kemudian double-click 'Properties' -> Settings, Pada baris ConnectionString terdapat Kolom 'Value'.
Ubah nama Data Source nya '(localdb)\mssqllocaldb' menjadi nama engine database yang anda gunakan.

Jalankan programnya ^^

Fitur :
1. User dapat menambahkan belanjaan dengan cara double-click pada kolom Kode-Barang dan baris yang diinginkan, kemudian input quantitynya.
2. User dapat menambahkan barang jualan. (Add)
3. User dapat mengedit/mengupdate barang jualannya dengan cara klik pada kolom Kode-Barang dan baris yang diinginkan, kemudian klik Edit.
4. User dapat menghapus barang jualannya dengan cara klik pada kolom Kode-Barang dan baris yang diinginkan, kemudian klik Delete.
5. User dapat mencari barang jualan yang diinginkan dengan search bar yang disediakan, hanya untuk Nama Barang.
6. User dapat menghapus list belanjaan yang sudah terdaftar. (Select row - delete)
7. User dapat melihat seluruh list jualan dan list belanjaan. (GridView)
8. User dapat melihat hasil akhir perbelanjaan. (klik Konfirmasi)

Unit Test : ada pada Project dengan nama 'AgileTeamCollabLibraryTests'
Yang di tes adalah class BarangDAOOffline (tidak ada koneksi ke database).
Jumlah Tests : 25