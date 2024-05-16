﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class MyValidator
    {
        // Person validation
        public bool ValidateFirstname(string firstname)
        {
            if (firstname.Length < 2 || firstname.Length > 25)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ValidateLastname(string lastname)
        {
            if (lastname.Length < 2 || lastname.Length > 25)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateEmail(string Email)
        {
            if (Email.Length < 5 || !Email.Contains("@") || !Email.Contains("."))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidatePhonenumber (int Phonenumber)
        {
            if (Phonenumber < 7 || Phonenumber >= 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        // Bolig validation

        public bool ValidateAdDress(string Address)
        {
            if (Address.Length < 5 || Address.Length > 35)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateZipcode (int Zipcode)
        {
            if (Zipcode < 1000 ||  Zipcode > 10000)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool ValidatePriceOfHouse( int Price)
        {
            if (Price < 0 || Price > 10000000)
            {
                return false;
            }
            else 
            { 
                return true; 
            }
        }
        public bool ValidateSquareMeter (int SquareMeter)
        {
            if (SquareMeter < 30 || SquareMeter > 1000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateSquarePrice (int SquarePrice)
        {
            if (SquarePrice < 1000 || SquarePrice > 250000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateHouseType( string HouseType)
        {
            if (!HouseType.Contains( "Villa") || !HouseType.Contains("Rækkehus") || !HouseType.Contains("Andelsbolig") || !HouseType.Contains("Lejlighed"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateSalesDate( DateTime SalesDate)
        {
            if (SalesDate.Year < 1850 || SalesDate.Date > DateTime.Now.Date)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
