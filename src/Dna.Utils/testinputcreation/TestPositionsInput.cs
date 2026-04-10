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

    /// <summary>
    /// Provides predefined sets of geographic <see cref="Position"/> instances for use in
    /// test and example optimization scenarios. Includes positions for Sydney (Australia)
    /// and New York area (Manhattan, New Jersey City) locations.
    /// </summary>
    public static class TestPositionsInput
    {

        /// <summary>
        /// Returns node positions located in Manhattan, New York.
        /// Used in zone-travel optimization examples together with <see cref="defaultNewJerseyCityNodePositions"/>.
        /// </summary>
        /// <returns>A list of 6 <see cref="Position"/> instances in Manhattan.</returns>
        public static List<Position> defaultManhattanNodePositions(){

            List<Position> poss = new List<Position>();

            poss.Add(new Position(40.764279, -73.988988, "Manhattan_0"));
            poss.Add(new Position(40.761822, -73.968600, "Manhattan_1"));
            poss.Add(new Position(40.764162, -73.991906, "Manhattan_2"));
            poss.Add(new Position(40.723670, -73.998738, "Manhattan_3"));
            poss.Add(new Position(40.796056, -73.967102, "Manhattan_4"));
            poss.Add(new Position(40.761964, -73.972156, "Manhattan_5"));

            //poss.Add(new Position(40.737567, -74.009090, "Manhattan_6"));
            //poss.Add(new Position(40.733846, -74.009090, "Manhattan_7"));

             return poss;
        }


        /// <summary>
        /// Returns node positions located in New Jersey City.
        /// Used in zone-travel optimization examples together with <see cref="defaultManhattanNodePositions"/>.
        /// </summary>
        /// <returns>A list of 5 <see cref="Position"/> instances in New Jersey City.</returns>
        public static List<Position> defaultNewJerseyCityNodePositions(){

            List<Position> poss = new List<Position>();

            poss.Add(new Position(40.751788, -74.027374, "NewJerseyCity_0"));
	        poss.Add(new Position(40.725626, -74.037277, "NewJerseyCity_1"));
            poss.Add(new Position(40.751106, -74.025960, "NewJerseyCity_2"));
            poss.Add(new Position(40.759971, -74.023066, "NewJerseyCity_3"));
            poss.Add(new Position(40.746625, -74.026088, "NewJerseyCity_4"));

            //poss.Add(new Position(40.748330, -74.057274, "NewJerseyCity_5"));
            //poss.Add(new Position(40.738185, -74.027539, "NewJerseyCity_6"));
            //poss.Add(new Position(40.740757, -74.026748, "NewJerseyCity_7"));

             return poss;
        }


        /// <summary>
        /// Returns node positions along a route near Sydney, Australia.
        /// This is the default node set used by most optimization examples.
        /// </summary>
        /// <returns>A list of 5 <see cref="Position"/> instances near Sydney.</returns>
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

        /// <summary>
        /// Returns resource starting positions in Queens, New York.
        /// Used by the zone-travel example with Manhattan and New Jersey City nodes.
        /// All three resources share the same starting location.
        /// </summary>
        /// <returns>A list of 3 <see cref="Position"/> instances in Queens, New York.</returns>
        public static List<Position> defaultNewYorkPositions()
        {

            List<Position> poss = new List<Position>();

            poss.Add(new Position(40.742728, -73.870528, "Resource_0"));
            poss.Add(new Position(40.742728, -73.870528, "Resource_1"));
            poss.Add(new Position(40.742728, -73.870528, "Resource_2"));

            return poss;

        }


        /// <summary>
        /// Returns resource starting positions near Sydney, Australia.
        /// This is the default resource set used by most optimization examples.
        /// </summary>
        /// <returns>A list of 4 <see cref="Position"/> instances near Sydney.</returns>
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
