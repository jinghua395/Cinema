using System.Threading.Tasks;

namespace Cinema.Domain.Room
{
    public interface IRoomRepository
    {
        Task<Room> GetRoom(string roomName); 

        void AddRoom(Room room); //not async on purpose, since change should be committed by SaveChanges()

        void UpdateRoom(Room room); //not async on purpose, since change should be committed by SaveChanges()
    }
}
