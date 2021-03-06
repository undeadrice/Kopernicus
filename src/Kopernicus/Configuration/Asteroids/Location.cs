﻿/**
 * Kopernicus Planetary System Modifier
 * ------------------------------------------------------------- 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301  USA
 * 
 * This library is intended to be used as a plugin for Kerbal Space Program
 * which is copyright 2011-2017 Squad. Your usage of Kerbal Space Program
 * itself is governed by the terms of its EULA, not the license above.
 * 
 * https://kerbalspaceprogram.com
 */

using System;
using System.Collections.Generic;

namespace Kopernicus
{
    namespace Configuration
    {
        namespace Asteroids
        {
            [RequireConfigType(ConfigType.Node)]
            public class Location
            {
                // Loads the nearby-Orbits of this Asteroid
                [RequireConfigType(ConfigType.Node)]
                public class NearbyLoader
                {
                    // The body we are passing
                    [ParserTarget("body")]
                    public String body { get; set; }

                    // eccentricity
                    [ParserTarget("eccentricity")]
                    public RandomRangeLoader eccentricity = new RandomRangeLoader(0.0001f, 0.01f);

                    // semiMajorAxis
                    [ParserTarget("semiMajorAxis")]
                    public RandomRangeLoader semiMajorAxis = new RandomRangeLoader(0.999f, 1.001f);

                    // inclination
                    [ParserTarget("inclination")]
                    public RandomRangeLoader inclination = new RandomRangeLoader(-0.001f, 0.001f);

                    // longitudeOfAscendingNode
                    [ParserTarget("longitudeOfAscendingNode")]
                    public RandomRangeLoader longitudeOfAscendingNode = new RandomRangeLoader(0.999f, 1.001f);

                    // argumentOfPeriapsis
                    [ParserTarget("argumentOfPeriapsis")]
                    public RandomRangeLoader argumentOfPeriapsis = new RandomRangeLoader(0.999f, 1.001f);

                    // meanAnomalyAtEpoch
                    [ParserTarget("meanAnomalyAtEpoch")]
                    public RandomRangeLoader meanAnomalyAtEpoch = new RandomRangeLoader(0.999f, 1.001f);

                    // The probability of this Orbit type
                    [ParserTarget("probability")]
                    public NumericParser<Single> probability { get; set; }

                    // Whether the body must be reached
                    [ParserTarget("reached")]
                    public NumericParser<Boolean> reached { get; set; }
                }

                // Loads the flyby-Orbits of this Asteroid
                [RequireConfigType(ConfigType.Node)]
                public class FlybyLoader
                {
                    // The body we are passing
                    [ParserTarget("body")]
                    public String body { get; set; }

                    // The minimum amount of days to closest approach
                    [ParserTarget("minDuration")]
                    public NumericParser<Single> minDuration { get; set; }

                    // The maximum amount of days to closest approach
                    [ParserTarget("maxDuration")]
                    public NumericParser<Single> maxDuration { get; set; }

                    // The probability of this Orbit type
                    [ParserTarget("probability")]
                    public NumericParser<Single> probability { get; set; }

                    // Whether the body must be reached
                    [ParserTarget("reached")]
                    public NumericParser<Boolean> reached { get; set; }
                }

                // Loads the around-Orbits of this Asteroid
                [RequireConfigType(ConfigType.Node)]
                public class AroundLoader
                {
                    // The body we are passing
                    [ParserTarget("body")]
                    public String body { get; set; }

                    // eccentricity
                    [ParserTarget("eccentricity")]
                    public RandomRangeLoader eccentricity = new RandomRangeLoader(0.0001f, 0.01f);

                    // semiMajorAxis
                    [ParserTarget("semiMajorAxis")]
                    public RandomRangeLoader semiMajorAxis { get; set; }

                    // inclination
                    [ParserTarget("inclination")]
                    public RandomRangeLoader inclination = new RandomRangeLoader(-0.001f, 0.001f);

                    // longitudeOfAscendingNode
                    [ParserTarget("longitudeOfAscendingNode")]
                    public RandomRangeLoader longitudeOfAscendingNode = new RandomRangeLoader(0.999f, 1.001f);

                    // argumentOfPeriapsis
                    [ParserTarget("argumentOfPeriapsis")]
                    public RandomRangeLoader argumentOfPeriapsis = new RandomRangeLoader(0.999f, 1.001f);

                    // meanAnomalyAtEpoch
                    [ParserTarget("meanAnomalyAtEpoch")]
                    public RandomRangeLoader meanAnomalyAtEpoch = new RandomRangeLoader(0.999f, 1.001f);

                    // epoch
                    [ParserTarget("epoch")]
                    public RandomRangeLoader epoch = new RandomRangeLoader(0.999f, 1.001f);

                    // The probability of this Orbit type
                    [ParserTarget("probability")]
                    public NumericParser<Single> probability { get; set; }

                    // Whether the body must be reached
                    [ParserTarget("reached")]
                    public NumericParser<Boolean> reached { get; set; }
                }

                // Loads a random range value
                [RequireConfigType(ConfigType.Node)]
                public class RandomRangeLoader
                {
                    // The min value
                    [ParserTarget("minValue")]
                    public NumericParser<Single> minValue { get; set; }

                    // The max value
                    [ParserTarget("maxValue")]
                    public NumericParser<Single> maxValue { get; set; }

                    // Convert this to Int32, and return a random value
                    public static implicit operator Single(RandomRangeLoader loader)
                    {
                        return UnityEngine.Random.Range(loader.minValue, loader.maxValue);
                    }

                    // Create a loader from given values
                    public RandomRangeLoader()
                    {
                        maxValue = 1;
                        minValue = 0;
                    }

                    // Create a loader from given values
                    public RandomRangeLoader(Single minValue, Single maxValue)
                    {
                        this.maxValue = maxValue;
                        this.minValue = minValue;
                    }
                }

                // Nearby-Orbits
                [ParserTargetCollection("Nearby", AllowMerge = true)]
                public List<NearbyLoader> nearby = new List<NearbyLoader>();

                // Flyby-Orbits
                [ParserTargetCollection("Flyby", AllowMerge = true)]
                public List<FlybyLoader> flyby = new List<FlybyLoader>();

                // Around-Orbits
                [ParserTargetCollection("Around", AllowMerge = true)]
                public List<AroundLoader> around = new List<AroundLoader>();
            }
        }
    }
}
