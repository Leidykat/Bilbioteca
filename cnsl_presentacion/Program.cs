// See https://aka.ms/new-console-template for more information
using cnsl_presentacion.Repositorios;

Console.WriteLine("Hello, World!");

var conexionEf = new ConexionEF();
//conexionEf.ConexionInsert();
conexionEf.ConexionBasica();