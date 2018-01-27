using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGraphSearch
{
    IGraphSearch Predecessor { get; set; }
    float PathLength { get; set; }
    Node CurrentNode { get; set; }
    Boolean Visited { get; set; }

    IGraphSearch shortestPath(Shape shape, List<IGraphSearch> reachable);
}
