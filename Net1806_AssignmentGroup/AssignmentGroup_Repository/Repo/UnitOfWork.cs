using AssignmentGroup_Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGroup_Repository.Repo
{
    public class UnitOfWork
    {
        private  CarDbSetContext context;
        private  GenericRepo<Car> _car;
        private GenericRepo<FuelType> _fuelType;
        private GenericRepo<Owner> _owner;
        private GenericRepo<SellerType> _sellerType;
        private GenericRepo<Transmission> _transsmisssion;

        public UnitOfWork(CarDbSetContext _context)
        {
            this.context = _context;    
        }

        public GenericRepo<Car> CarRepository
        {
            get
            {
                if (_car == null)
                {
                    this._car = new GenericRepo<Car>(context);
                }
                return _car;
            }

        }
        public void Save()
        {
            context.SaveChanges();
        }

        public GenericRepo<FuelType> FuelTypeRepository
        {
            get
            {
                if (_fuelType == null)
                {
                    this._fuelType = new GenericRepo<FuelType>(context);
                }
                return _fuelType;
            }

        }

        public GenericRepo<Owner> OwnerRepository
        {
            get
            {
                if (_owner == null)
                {
                    this._owner = new GenericRepo<Owner>(context);
                }
                return _owner;
            }

        }

        public GenericRepo<SellerType> SellerTypeRepository
        {
            get
            {
                if (_sellerType == null)
                {
                    this._sellerType = new GenericRepo<SellerType>(context);
                }
                return _sellerType;
            }

        }

        public GenericRepo<Transmission> TransmissionRepository
        {
            get
            {
                if (_transsmisssion == null)
                {
                    this._transsmisssion = new GenericRepo<Transmission>(context);
                }
                return _transsmisssion;
            }

        }
    }
}
