# Omino

Application that arranges blocks on a board.  
There might be extra condition applied:
- blocks might be only arranged on a square, minimal square size is desired.
- blocks might be arranged on a minimal area rectangle, but cutting blocks is possible. Whole rectangle must be covered, minimal number of cuts is desired.

There are several alghoritms implemented that either optimize desired problem or time.

# Building

To build application:

1. Make sure you are in project directory:
```
cd Omino
```
2. Build the project using `dotnet`:
```
dotnet build --configuration Release
```
3. After successful build application should appear be in `.\bin\Release`