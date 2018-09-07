namespace Easv.PetShop.Core.Domain_Service
{
    public interface IOwnerRepository
    {
        //Create
        Owner CreateOwner(Owner owner);

        //Read
        IEnumerable<Pet> ReadOwner();
        Owner ReadOwnerById(int id);

        //Update
        Owner UpdateOwner(Owner updateOwner);

        //Delete
        Owner DeleteOwner(int id);
    }
}