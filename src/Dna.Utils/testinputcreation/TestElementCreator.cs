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
using Utils;
using Org.OpenAPITools.Model;
using System.Collections.Generic;


namespace Utils
{
    /// <summary>
    /// Factory for creating default <see cref="Node"/> and <see cref="Resource"/> instances
    /// suitable for testing and example purposes.
    /// All elements use a fixed 5-day schedule (Jan 1-5, 2100) in the Europe/Berlin timezone.
    /// </summary>
    public static class TestElementCreator
    {
        /*
            *
            * Resource specific
            *
            */

        /// <summary>
        /// Creates a default capacity-based <see cref="Resource"/> at the given position.
        /// Configured with a 12-hour max working time, 1200 km max distance, and 5-day working hours.
        /// </summary>
        /// <param name="pos">The geographic starting position of the resource.</param>
        /// <param name="id">The unique identifier for the resource.</param>
        /// <returns>A new <see cref="Resource"/> with default capacity settings.</returns>
        public static Resource defaultCapacityResource(Position pos, String id)
        {

            CapacityResource type = new CapacityResource();
            type.TypeName = "Capacity";
            string maxTime = "PT12H";
            string maxDistance = "1200.0 km";

            List<double> capacity = new List<double>();
            List<double> initialLoad = new List<double>();
            List<double> minDegratedCapacity = new List<double>();
            List<double> capacityDegPerStop = new List<double>();
            List<Qualification> qualifications = new List<Qualification>();

            Resource res = new Resource(id: id,
                locationId: pos.LocationId,
                type: type, position: pos,
                workingHours: defaultTestWorkinghours(),
                maxTime: maxTime,
                maxDistance: maxDistance,
                capacity: capacity,
                initialLoad: initialLoad,
                minDegratedCapacity: minDegratedCapacity,
                capacityDegPerStop: capacityDegPerStop,
                qualifications: qualifications);

            return res;
        }

        /// <summary>
        /// Creates a default capacity-based <see cref="Resource"/> with a <see cref="TypeQualification"/>
        /// that the resource can provide. Used to demonstrate qualification-constraint matching.
        /// </summary>
        /// <param name="pos">The geographic starting position of the resource.</param>
        /// <param name="id">The unique identifier for the resource.</param>
        /// <param name="qualificationDesc">The qualification type name this resource provides (e.g. "Quali").</param>
        /// <returns>A new <see cref="Resource"/> with the specified type qualification.</returns>
        public static Resource defaultCapacityResourceWithQualificationConstraint(Position pos, String id, String qualificationDesc)
        {

            CapacityResource type = new CapacityResource();
            type.TypeName = "Capacity";
            string maxTime = "PT12H";
            string maxDistance = "1200.0 km";

            List<double> capacity = new List<double>();
            List<double> initialLoad = new List<double>();
            List<double> minDegratedCapacity = new List<double>();
            List<double> capacityDegPerStop = new List<double>();

            Resource res = new Resource(id: id,
                locationId: pos.LocationId,
                type: type, position: pos,
                workingHours: defaultTestWorkinghours(),
                maxTime: maxTime,
                maxDistance: maxDistance,
                capacity: capacity,
                initialLoad: initialLoad,
                minDegratedCapacity: minDegratedCapacity,
                capacityDegPerStop: capacityDegPerStop,
                qualifications: createTypeQualifcations(qualificationDesc));

            return res;
        }

        /// <summary>
        /// Creates a list containing a single <see cref="TypeQualification"/> with the given name.
        /// Used to assign a type-based qualification to a resource.
        /// </summary>
        /// <param name="exampleQuali">The qualification type name (e.g. "Quali").</param>
        /// <returns>A list with one <see cref="Qualification"/> wrapping a <see cref="TypeQualification"/>.</returns>
        public static List<Qualification> createTypeQualifcations(string exampleQuali)
        {

            List<Qualification> qualifications = new List<Qualification>();

            List<string> typeQualis = new List<string>();

            typeQualis.Add(exampleQuali);

            TypeQualification quali = new TypeQualification(typeQualis);

            //quali.TypeNames = typeQualis;

            // Add to list
            qualifications.Add(new Qualification(quali));

            return qualifications;

        }


        /// <summary>
        /// Creates a list containing a single <see cref="ZoneNumberQualification"/> for the given zone number.
        /// Used to assign zone-based qualifications to nodes for zone-travel optimization scenarios.
        /// </summary>
        /// <param name="zoneNumberInt">The zone number identifier.</param>
        /// <returns>A list with one <see cref="Qualification"/> wrapping a <see cref="ZoneNumberQualification"/>.</returns>
        public static List<Qualification> createZoneQualifcations(int zoneNumberInt)
        {

            ZoneNumber zoneNumber = new ZoneNumber(zoneNumberInt);
            ZoneNumberQualification zoneNumberQuali = new ZoneNumberQualification(zoneNumber);


            List<Qualification> qualifications =
            [
                // Add to list
                new Qualification(zoneNumberQuali),
            ];

            return qualifications;

        }

        /// <summary>
        /// Creates default working hours for resources spanning 5 consecutive days (Jan 1-5, 2100),
        /// each from 08:00 to 20:00 in the Europe/Berlin timezone.
        /// </summary>
        /// <returns>A list of 5 <see cref="WorkingHours"/> entries.</returns>
        public static List<WorkingHours> defaultTestWorkinghours()
        {

            String zoneId = "Europe/Berlin";

            int numDays = 5;

            /*
             *
             */
            List<WorkingHours> workingHours = new List<WorkingHours>();

            for (int i = 0; i < numDays; i++)
            {
                DateTime start = new DateTime(2100, 1, 1 + i, 8, 0, 0, 0, DateTimeKind.Utc);
                DateTime end = new DateTime(2100, 1, 1 + i, 20, 0, 0, 0, DateTimeKind.Utc);

                workingHours.Add(createWorkingHours(start, end, zoneId));
            }

            return workingHours;
        }

        /// <summary>
        /// Creates a single <see cref="WorkingHours"/> entry with the given time window and timezone.
        /// </summary>
        /// <param name="begin">The start of the working window (UTC).</param>
        /// <param name="end">The end of the working window (UTC).</param>
        /// <param name="zoneId">The IANA timezone identifier (e.g. "Europe/Berlin").</param>
        /// <returns>A new <see cref="WorkingHours"/> instance.</returns>
        public static WorkingHours createWorkingHours(DateTime begin, DateTime end, String zoneId)
        {

            WorkingHours hr = new WorkingHours(begin, end, zoneId);

            return hr;
        }

        /*
         *
         * Node specific
         *
         */


        /// <summary>
        /// Creates a default geographic <see cref="Node"/> at the given position with a 30-minute visit duration,
        /// priority 1, and 5-day opening hours. No constraints, loads, or qualifications are set.
        /// </summary>
        /// <param name="pos">The geographic position of the node.</param>
        /// <param name="id">The unique identifier for the node.</param>
        /// <returns>A new <see cref="Node"/> with default settings.</returns>
        public static Node defaultGeoNode(Position pos, String id)
        {

            GeoNode geoPart = new GeoNode(pos);
            geoPart.TypeName = "Geo";

            string visitDuration = "PT30M";


            List<Constraint> constrains = new List<Constraint>();
            List<double> load = new List<double>();
            List<Qualification> qualifications = new List<Qualification>();

            Node node = new Node(id: id,
                locationId: pos.LocationId,
                type: geoPart,
                openingHours: defaultTestOpeninghours(),
                visitDuration: visitDuration,
                constraints: constrains,
                load: load,
                qualifications: qualifications);

            node.Priority = 1;

            return node;
        }

        /// <summary>
        /// Creates a geographic <see cref="Node"/> with a <see cref="TypeConstraint"/> that must be
        /// satisfied by a matching resource qualification. Used to demonstrate constraint violations.
        /// </summary>
        /// <param name="pos">The geographic position of the node.</param>
        /// <param name="id">The unique identifier for the node.</param>
        /// <param name="typeConstraintTitle">The type constraint name the node requires (e.g. "UnreachableQuali").</param>
        /// <returns>A new <see cref="Node"/> with the specified type constraint.</returns>
        public static Node defaultGeoNodeWithTypeConstraint(Position pos, String id, String typeConstraintTitle)
        {

            GeoNode geoPart = new GeoNode(pos);
            geoPart.TypeName = "Geo";

            string visitDuration = "PT30M";


            List<Constraint> constrains = new List<Constraint>();
            List<double> load = new List<double>();
            List<Qualification> qualifications = new List<Qualification>();

            Node node = new Node(id: id,
                locationId: pos.LocationId,
                type: geoPart,
                openingHours: defaultTestOpeninghours(),
                visitDuration: visitDuration,
                constraints: createNodeTypeConstraints(typeConstraintTitle),
                load: load,
                qualifications: qualifications);

            node.Priority = 1;

            return node;
        }


        /// <summary>
        /// Creates a geographic <see cref="Node"/> with a <see cref="ZoneNumberQualification"/>.
        /// Used for zone-travel optimization where crossing between zones incurs a penalty.
        /// </summary>
        /// <param name="pos">The geographic position of the node.</param>
        /// <param name="id">The unique identifier for the node.</param>
        /// <param name="zoneNumber">The zone number this node belongs to.</param>
        /// <returns>A new <see cref="Node"/> with the specified zone qualification.</returns>
        public static Node defaultGeoNodeWithZoneQualification(Position pos, String id, int zoneNumber)
        {

            GeoNode geoPart = new GeoNode(pos);
            geoPart.TypeName = "Geo";

            string visitDuration = "PT30M";


            List<Constraint> constrains = new List<Constraint>();
            List<double> load = new List<double>();
            List<Qualification> qualifications = createZoneQualifcations(zoneNumber);

            Node node = new Node(id: id,
                locationId: pos.LocationId,
                type: geoPart,
                openingHours: defaultTestOpeninghours(),
                visitDuration: visitDuration,
                constraints: constrains,
                load: load,
                qualifications: qualifications);

            node.Priority = 1;

            return node;
        }


        /// <summary>
        /// Creates a list containing a single <see cref="TypeConstraint"/> with the given title.
        /// The resulting constraint requires a matching <see cref="TypeQualification"/> on the assigned resource.
        /// </summary>
        /// <param name="nodeTypeConstraintTitle">The type constraint name (e.g. "UnreachableQuali").</param>
        /// <returns>A list with one <see cref="Constraint"/> wrapping a <see cref="TypeConstraint"/>.</returns>
        public static List<Constraint> createNodeTypeConstraints(string nodeTypeConstraintTitle)
        {

            List<Constraint> constraints = new List<Constraint>();

            // Type

            List<string> typeConstraintTitles = new List<string>();

            typeConstraintTitles.Add(nodeTypeConstraintTitle);

            TypeConstraint typeConstraint = new TypeConstraint(typeConstraintTitles);

            // Add to List
            constraints.Add(new Constraint(type: typeConstraint));

            return constraints;

        }

        /// <summary>
        /// Returns the default opening hours for a single day, selected by index from the 5-day schedule.
        /// </summary>
        /// <param name="choosenSingleDayIndex">Zero-based index of the day to select (0-4).</param>
        /// <returns>A list with one <see cref="OpeningHours"/> entry for the selected day.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <paramref name="choosenSingleDayIndex"/> is negative or exceeds the available days.</exception>
        public static List<OpeningHours> defaultTestOpeninghours(int choosenSingleDayIndex)
        {

            if (choosenSingleDayIndex < 0)
            {
                throw new InvalidOperationException("Choosen day index cannot be negative");
            }

            List<OpeningHours> fullHours = defaultTestOpeninghours();

            if (choosenSingleDayIndex > fullHours.Count - 1)
            {
                throw new InvalidOperationException("Choosen day cannot be greater than " + (fullHours.Count - 1));
            }


            List<OpeningHours> openingHours = new List<OpeningHours>();

            openingHours.Add(fullHours[choosenSingleDayIndex]);

            return openingHours;
        }

        /// <summary>
        /// Creates default opening hours for nodes spanning 5 consecutive days (Jan 1-5, 2100),
        /// each from 08:00 to 20:00 in the Europe/Berlin timezone.
        /// </summary>
        /// <returns>A list of 5 <see cref="OpeningHours"/> entries.</returns>
        public static List<OpeningHours> defaultTestOpeninghours()
        {

            String zoneId = "Europe/Berlin";

            int numDays = 5;

            /*
             *
             */
            List<OpeningHours> openingHours = new List<OpeningHours>();

            for (int i = 0; i < numDays; i++)
            {
                DateTime start = new DateTime(2100, 1, 1 + i, 8, 0, 0, 0, DateTimeKind.Utc);
                DateTime end = new DateTime(2100, 1, 1 + i, 20, 0, 0, 0, DateTimeKind.Utc);

                openingHours.Add(createOpeningHours(start, end, zoneId));
            }

            return openingHours;

        }

        /// <summary>
        /// Creates a single <see cref="OpeningHours"/> entry with the given time window and timezone.
        /// </summary>
        /// <param name="begin">The start of the opening window (UTC).</param>
        /// <param name="end">The end of the opening window (UTC).</param>
        /// <param name="zoneId">The IANA timezone identifier (e.g. "Europe/Berlin").</param>
        /// <returns>A new <see cref="OpeningHours"/> instance.</returns>
        public static OpeningHours createOpeningHours(DateTime begin, DateTime end, String zoneId)
        {

            OpeningHours hr = new OpeningHours(begin, end, zoneId);

            return hr;
        }


    }
}
