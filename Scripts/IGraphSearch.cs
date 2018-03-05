using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Filip
public interface IGraphSearch
{
    IGraphSearch Predecessor { get; set; }
    float PathLength { get; set; }
    Node CurrentNode { get; set; }
    Boolean Visited { get; set; }
    ISynapseConnection connection { get; set; }

    List<IGraphSearch> shortestPath(Shape shape, List<IGraphSearch> reachable);
}
