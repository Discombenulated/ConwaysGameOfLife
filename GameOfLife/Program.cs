// See https://aka.ms/new-console-template for more information
using GameOfLife;

Console.WriteLine("Press any key to begin");
Console.ReadKey();
Console.Clear();
Console.WriteLine("Hello, World!");
Thread.Sleep(1000);
Console.Clear();
Console.WriteLine("Hello, Ben!");
Grid g = new PentadecathalonGrid();

for (int i = 0; i < 60; i++){
    Console.Clear();
    var output = g.ToString();
    output = output.Replace("0", " ").Replace("1", ((char)9632).ToString());
    Console.WriteLine(output);
    Thread.Sleep(500);
    g = g.Step();
}