public interface ISynapseConnection
{
    Node AccessibleNode { get; set; }
    float Weight { get; set; }

    bool transferData(Data_Script data);

    bool canTransfer(Shape data);
}
