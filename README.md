# ConwaysGameOfLife

Rules based on https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

Created with dotnet-cli

dotnet new sln
dotnet new console -n GameOfLife
dotnet sln add GameOfLife
dotnet new nunit -n GameOfLife.Test
dotnet sln add GameOfLife.Test
dotnet add ./GameOfLife.Test/GameOfLife.Test.csproj reference ./GameOfLife/GameOfLife.csproj