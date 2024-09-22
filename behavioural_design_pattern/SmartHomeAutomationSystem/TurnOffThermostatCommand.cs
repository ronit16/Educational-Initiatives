public class TurnOffThermostatCommand : ICommand
{
    private Thermostat _thermostat;

    public TurnOffThermostatCommand(Thermostat thermostat)
    {
        _thermostat = thermostat ?? throw new ArgumentNullException(nameof(thermostat));
    }

    public void Execute()
    {
        _thermostat.TurnOff();
    }

    public void Undo()
    {
        _thermostat.TurnOn();
    }
}
