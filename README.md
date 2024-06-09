<h1 align="center">TheMan</h1>
<h3 align="center">(Tugas Besar 3 IF2211 Strategi Algoritma)</h3>

# Deskripsi
Mahasiswa ditugaskan membuat sebuah perangkat lunak berupa aplikasi desktop yang dapat mencocokkan gambar sidik jari pada basis data tertentu. Pencocokan dilakukan dengan algoritme string matching Knuth-Morris-Pratt dan Boyer-Moore.

# Algoritme Knuth Moris Pratt
Algoritme Knuth-Morris-Pratt (KMP) adalah salah satu algoritme yang efisien untuk string matching. Algoritme ini diperkenalkan oleh Donald Knuth, Vaughan Pratt, dan James H. Morris pada tahun 1977. Algoritme KMP bekerja dengan menggunakan informasi dari pattern itu sendiri yang disini dinamakan border function atau fungsi pinggiran yang berguna untuk menghindari perbandingan ulang yang tidak perlu saat terjadi ketidakcocokan

# Algoritme Boyer-Moore
Algoritme Boyer-Moore adalah salah satu algoritme string matching yang efisien dan banyak digunakan, terutama ketika pola yang dicari relatif panjang dibandingkan dengan teks. Algoritme ini dibagi menjadi dua teknik, yaitu looking glass technique (temukan P (pattern) di T (teks)  dengan bergerak mundur melalui P, dimulai dari ujungnya)  dan character jump technique ( Teknik ini menggunakan tabel Last Occurrence untuk menentukan seberapa jauh pola dapat digeser saat terjadi ketidakcocokan).

# Dependencies
1. This program can only be run on Windows as it is a WinForms based application. If you would like to run it on Linux, for example, you will need to download either an emulator or an adapter software such as wine.
2. You will need to have docker installed.

# How To Compile
1. Open Visual Studio
2. Browse to the project's folder and select the src.sln file inside of the src folder
3. On the toolbar click Build -> Rebuild Solution

# How to Set Up Fingerprint Data
1. Download the SOCOFing database from this kaggle link https://www.kaggle.com/datasets/ruizgara/socofing
2. Extract the data and place it inside the Data directory from the project's folder

# How To Run
1. Open the terminal in the project's folder
2. Run the following script (make sure Docker is already running, if not launch it first)
```bash
docker-compose up -d
```
4. Run the following script to seed the database when running the program for the first time
```bash
./seedDB.bat
```
5. Run the following script to start the program
```bash
./run.bat
```
6. When done using the program run the following script to stop the docker and erase the database data
```bash
docker-compose down -v
```
   
# Authors
|Anggota|NIM|
|-------|---|
|Renaldy Arief Susanto|13522022|
|Abdul Rafi Radityo Hutomo|13522089|
|Rayhan Fadhlan Azka|13522095|
