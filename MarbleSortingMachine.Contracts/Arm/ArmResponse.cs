namespace MarbleSortingMachine.Contracts.Arm
{
    public record ArmResponse
    {
        public List<ContainerResult> Containers { get; set; }
    }

    public record ContainerResult
    {
        public string Color { get; set; }
        public long Count { get; set; }
    }
}
