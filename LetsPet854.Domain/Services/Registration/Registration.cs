﻿using LetsPet854.Domain.Common.Enuns;
using LetsPet854.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPet854.Domain
{
    public class Registration
    {
        public static string Type;
        public static string Species;
        public static string Size;
        public static string Name;
        public static bool Special;
        public static bool Lotion;
        public static string GroomingType = "";
        public static int ServiceTime = 1;
        public static double Price;
        public static int option;
        public static int order;
        public static string validate;
        public static List<Service> ServicesList = new();

        public static void AddService()
        {
            do
            {
                Console.WriteLine("O que você deseja cadastrar?");
                ShowInfo.EnumServiceType();
            } while (!int.TryParse(Console.ReadLine(), out order) || (order < 1 || order > 2));
            Type = Enum.GetName(typeof(ServiceType), order);

            if (order == 2)
            {
                do
                {
                    Console.WriteLine("Qual o tipo de tosa a ser realizado?");
                    ShowInfo.EnumGroomingType();
                } while (!int.TryParse(Console.ReadLine(), out order) || (order < 1 || order > 3));
                GroomingType = Enum.GetName(typeof(GroomingType), order);
            }
            else
            {
                GroomingType = null;
            }

            do
            {
                Console.WriteLine("Para qual espécie é este serviço?");
                ShowInfo.EnumSpecies();
            } while (!int.TryParse(Console.ReadLine(), out order) || (order < 1 || order > 2));
            Species = Enum.GetName(typeof(Species), order);

            do
            {
                Console.WriteLine("Para qual porte é este serviço?");
                ShowInfo.EnumBreedSize();
            } while (!int.TryParse(Console.ReadLine(), out order) || (order < 1 || order > 2));
            Size = Enum.GetName(typeof(BreedSize), order);

            do
            {
                Console.WriteLine("É um serviço especial (S/N)?");
                validate = Console.ReadLine().ToUpper();
            } while (!Validations.Resposta(validate));
            Special = Validations.SimNao(validate);

            do
            {
                Console.WriteLine("Esse serviço utilizará loção (S/N)?");
                validate = Console.ReadLine().ToUpper();
            } while (!Validations.Resposta(validate));
            Lotion = Validations.SimNao(validate);

            do
            {
                Console.WriteLine("Qual o nome deste serviço?");
                Name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(Name)); //não aceitar nomes já existentes

            do
            {
                Console.WriteLine("Qual o valor deste serviço?");
            } while (!double.TryParse(Console.ReadLine(), out Price));

            Service newService = new Service(Type, Species, Size, Name, Special, Lotion, GroomingType, ServiceTime, Price);
            ServicesList.Add(newService);
            Console.WriteLine("Cadastro Realizado!\n");

            ShowInfo.ByName(newService.Name);
        }

        public static void AddDiscount()
        {
            Console.WriteLine("Escolha um serviço:");
        }
    }
}
