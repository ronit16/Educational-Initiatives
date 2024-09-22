public class TurnOnThermostatCommand : ICommand
{
    private Thermostat _thermostat;

    public TurnOnThermostatCommand(Thermostat thermostat)
    {
        _thermostat = thermostat ?? throw new ArgumentNullException(nameof(thermostat));
    }

    public void Execute()
    {
        _thermostat.TurnOn();
    }

    public void Undo()
    {
        _thermostat.TurnOff();
    }
}
