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
    public static class TestElementCreator
    {
        /*
            *
            * Resource specific
            *
            */

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

        
        public static List<Constraint> createNodeTypeConstraints(string nodeTypeConstraintTitle)
        {

            List<Constraint> constraints = new List<Constraint>();

            // Type

            List<string> typeConstraintTitles = new List<string>();

            typeConstraintTitles.Add(nodeTypeConstraintTitle);

            TypeConstraint typeConstraint = new TypeConstraint(typeConstraintTitles);

            // Add to List
            constraints.Add(new Constraint(typeConstraint));

            return constraints;

        }

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

        public static OpeningHours createOpeningHours(DateTime begin, DateTime end, String zoneId)
        {

            OpeningHours hr = new OpeningHours(begin, end, zoneId);

            return hr;
        }


    }
}