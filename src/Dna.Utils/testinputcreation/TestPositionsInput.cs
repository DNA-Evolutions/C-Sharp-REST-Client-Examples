/*-
 * #%L
 * JOpt C# REST Client Examples
 * %%
 * Copyright (C) 2017 - 2022 DNA Evolutions GmbH
 * %%
 * This file is subject to the terms and conditions defined in file 'LICENSE.md',
 * which is part of this repository.
 * 
 * If not, see <https://www.dna-evolutions.com/agb-conditions-and-terms/>.
 * #L%
 */

using System;
using System.Collections.Generic;
using Org.OpenAPITools.Model;


namespace Utils
{

    public static class TestPositionsInput
    {

        public static List<Position> defaultSydneyNodePositions()
        {

            List<Position> poss = new List<Position>();

            poss.Add(new Position(-34.052052, 150.668724, "Node_0"));
            poss.Add(new Position(-34.052518, 150.709943, "Node_1"));
            poss.Add(new Position(-34.051988, 150.71981, "Node_2"));
            poss.Add(new Position(-34.04213, 150.729568, "Node_3"));
            poss.Add(new Position(-34.042063, 150.739632, "Node_4"));
           
           /* poss.Add(new Position(-34.041006, 150.779042, "Node_5"));
            poss.Add(new Position(-34.042611, 150.800852, "Node_6"));
            poss.Add(new Position(-34.042334, 150.830416, "Node_7"));
            poss.Add(new Position(-34.041776, 150.839277, "Node_8"));
            poss.Add(new Position(-34.032093, 150.849402, "Node_9"));
            poss.Add(new Position(-34.032283, 150.860021, "Node_10"));
            poss.Add(new Position(-34.033504, 150.885173, "Node_11"));
            poss.Add(new Position(-34.016844, 150.901184, "Node_12"));
            poss.Add(new Position(-34.032085, 151.009819, "Node_13"));
            poss.Add(new Position(-34.03345, 151.019328, "Node_14"));
            poss.Add(new Position(-34.032983, 151.050504, "Node_15"));
            poss.Add(new Position(-34.031779, 151.059578, "Node_16"));
            poss.Add(new Position(-34.021961, 151.019686, "Node_17"));
            poss.Add(new Position(-34.02273, 151.030557, "Node_18"));
            poss.Add(new Position(-34.08002, 150.999438, "Node_19"));
            poss.Add(new Position(-34.022009, 151.069768, "Node_20"));
            poss.Add(new Position(-34.02241, 151.098778, "Node_21"));
            poss.Add(new Position(-34.022038, 151.109346, "Node_22"));
            poss.Add(new Position(-34.052077, 150.69951, "Node_23"));
            poss.Add(new Position(-34.051068, 150.976722, "Node_24"));
            poss.Add(new Position(-34.052015, 150.999808, "Node_25"));*/

            return poss;

        }

        public static List<Position> defaultSydneyResourcePositions()
        {

            List<Position> poss = new List<Position>();

            poss.Add(new Position(-34.052052, 150.668724, "Resource_0"));
            poss.Add(new Position(-34.052518, 150.709943, "Resource_1"));
            poss.Add(new Position(-34.051988, 150.71981, "Resource_2"));
            poss.Add(new Position(-34.052015, 150.999808, "Resource_3"));

            return poss;

        }
    }

}