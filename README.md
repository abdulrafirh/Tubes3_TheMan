# How To Compile
1. Open Visual Studio
2. Browse to the project's folder and select the src.sln file inside of the src folder
3. On the toolbar click Build -> Rebuild Solution

# How To Run
1. Open the terminal in the project's folder
2. Run the following script
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
   
