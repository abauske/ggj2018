public interface ISynapseConnection
{
    Node AccessibleNode { get; set; }
    float Weight { get; set; }

    bool transferData(Data_Script data, IGraphSearch transfer);

    bool canTransfer(Shape data);
}
