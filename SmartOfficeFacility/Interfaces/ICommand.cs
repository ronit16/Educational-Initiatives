namespace SmartOfficeFacility.Interfaces
{
    public interface ICommand
    {
        void Execute(int roomNumber, int duration);
        void Execute(int roomNumber);
    }
}
