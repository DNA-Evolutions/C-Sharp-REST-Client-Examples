/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc2-j17)
 *
 * The version of the OpenAPI document: 1.2.8-alpha-SNAPSHOT)
 * Contact: info@dna-evolutions.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// The header of the whole solution. Summarizing important data like total number of routes, total time needed for ALL routes etc.
    /// </summary>
    [DataContract(Name = "SolutionHeader")]
    public partial class SolutionHeader : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionHeader" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SolutionHeader() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionHeader" /> class.
        /// </summary>
        /// <param name="numRoutes">The numRoutes. The number of routes. (required).</param>
        /// <param name="numScheduledRoutes">The numScheduledRoutes. The number of routes that have non-zero time. (required).</param>
        /// <param name="totElements">The total number of Elements inlucidng Nodes and Resoures (required).</param>
        /// <param name="unassignedElementIds">The unassignedElementIds, The ids of the elements that were unassigned during the Optimization run. Either by the AutoFilter or at start up due to conflicting hard-constraints. (required).</param>
        /// <param name="totCost">The total cost is the abstract value that is used as figure of merit during the Optimization run. (required).</param>
        /// <param name="totTime">The total time needed for all routes. (required).</param>
        /// <param name="totIdleTime">The total IdleTime accumulated over all routes. (required).</param>
        /// <param name="totProdTime">The total Productive Time accumulated over all routes (required).</param>
        /// <param name="totTranTime">The total transit Time accumulated over all routes (required).</param>
        /// <param name="totTermiTime">The total termination Time accumulated over all routes (required).</param>
        /// <param name="totDistance">The total distance accumulated over all routes (required).</param>
        /// <param name="totTermiDistance">The total termiantion distance accumulated over all routes (required).</param>
        /// <param name="jobViolations">The jobViolations. The violation that occured on Job level. This does NOT contain individual node violations like lateness etc. Moreover,  it contains violations like relation-constraints between nodes. For example, node &#39;A&#39; needs to be visited before node &#39;B&#39; is violated. (required).</param>
        public SolutionHeader(int numRoutes = default(int), int numScheduledRoutes = default(int), int totElements = default(int), List<string> unassignedElementIds = default(List<string>), double totCost = default(double), string totTime = default(string), string totIdleTime = default(string), string totProdTime = default(string), string totTranTime = default(string), string totTermiTime = default(string), string totDistance = default(string), string totTermiDistance = default(string), List<Violation> jobViolations = default(List<Violation>))
        {
            this.NumRoutes = numRoutes;
            this.NumScheduledRoutes = numScheduledRoutes;
            this.TotElements = totElements;
            // to ensure "unassignedElementIds" is required (not null)
            if (unassignedElementIds == null)
            {
                throw new ArgumentNullException("unassignedElementIds is a required property for SolutionHeader and cannot be null");
            }
            this.UnassignedElementIds = unassignedElementIds;
            this.TotCost = totCost;
            // to ensure "totTime" is required (not null)
            if (totTime == null)
            {
                throw new ArgumentNullException("totTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotTime = totTime;
            // to ensure "totIdleTime" is required (not null)
            if (totIdleTime == null)
            {
                throw new ArgumentNullException("totIdleTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotIdleTime = totIdleTime;
            // to ensure "totProdTime" is required (not null)
            if (totProdTime == null)
            {
                throw new ArgumentNullException("totProdTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotProdTime = totProdTime;
            // to ensure "totTranTime" is required (not null)
            if (totTranTime == null)
            {
                throw new ArgumentNullException("totTranTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotTranTime = totTranTime;
            // to ensure "totTermiTime" is required (not null)
            if (totTermiTime == null)
            {
                throw new ArgumentNullException("totTermiTime is a required property for SolutionHeader and cannot be null");
            }
            this.TotTermiTime = totTermiTime;
            // to ensure "totDistance" is required (not null)
            if (totDistance == null)
            {
                throw new ArgumentNullException("totDistance is a required property for SolutionHeader and cannot be null");
            }
            this.TotDistance = totDistance;
            // to ensure "totTermiDistance" is required (not null)
            if (totTermiDistance == null)
            {
                throw new ArgumentNullException("totTermiDistance is a required property for SolutionHeader and cannot be null");
            }
            this.TotTermiDistance = totTermiDistance;
            // to ensure "jobViolations" is required (not null)
            if (jobViolations == null)
            {
                throw new ArgumentNullException("jobViolations is a required property for SolutionHeader and cannot be null");
            }
            this.JobViolations = jobViolations;
        }

        /// <summary>
        /// The numRoutes. The number of routes.
        /// </summary>
        /// <value>The numRoutes. The number of routes.</value>
        /// <example>10</example>
        [DataMember(Name = "numRoutes", IsRequired = true, EmitDefaultValue = true)]
        public int NumRoutes { get; set; }

        /// <summary>
        /// The numScheduledRoutes. The number of routes that have non-zero time.
        /// </summary>
        /// <value>The numScheduledRoutes. The number of routes that have non-zero time.</value>
        /// <example>8</example>
        [DataMember(Name = "numScheduledRoutes", IsRequired = true, EmitDefaultValue = true)]
        public int NumScheduledRoutes { get; set; }

        /// <summary>
        /// The total number of Elements inlucidng Nodes and Resoures
        /// </summary>
        /// <value>The total number of Elements inlucidng Nodes and Resoures</value>
        /// <example>516</example>
        [DataMember(Name = "totElements", IsRequired = true, EmitDefaultValue = true)]
        public int TotElements { get; set; }

        /// <summary>
        /// The unassignedElementIds, The ids of the elements that were unassigned during the Optimization run. Either by the AutoFilter or at start up due to conflicting hard-constraints.
        /// </summary>
        /// <value>The unassignedElementIds, The ids of the elements that were unassigned during the Optimization run. Either by the AutoFilter or at start up due to conflicting hard-constraints.</value>
        [DataMember(Name = "unassignedElementIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> UnassignedElementIds { get; set; }

        /// <summary>
        /// The total cost is the abstract value that is used as figure of merit during the Optimization run.
        /// </summary>
        /// <value>The total cost is the abstract value that is used as figure of merit during the Optimization run.</value>
        /// <example>95164.1314</example>
        [DataMember(Name = "totCost", IsRequired = true, EmitDefaultValue = true)]
        public double TotCost { get; set; }

        /// <summary>
        /// The total time needed for all routes.
        /// </summary>
        /// <value>The total time needed for all routes.</value>
        /// <example>PT480M</example>
        [DataMember(Name = "totTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotTime { get; set; }

        /// <summary>
        /// The total IdleTime accumulated over all routes.
        /// </summary>
        /// <value>The total IdleTime accumulated over all routes.</value>
        /// <example>PT30M</example>
        [DataMember(Name = "totIdleTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotIdleTime { get; set; }

        /// <summary>
        /// The total Productive Time accumulated over all routes
        /// </summary>
        /// <value>The total Productive Time accumulated over all routes</value>
        /// <example>PT300M</example>
        [DataMember(Name = "totProdTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotProdTime { get; set; }

        /// <summary>
        /// The total transit Time accumulated over all routes
        /// </summary>
        /// <value>The total transit Time accumulated over all routes</value>
        /// <example>PT200M</example>
        [DataMember(Name = "totTranTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotTranTime { get; set; }

        /// <summary>
        /// The total termination Time accumulated over all routes
        /// </summary>
        /// <value>The total termination Time accumulated over all routes</value>
        /// <example>PT30M</example>
        [DataMember(Name = "totTermiTime", IsRequired = true, EmitDefaultValue = true)]
        public string TotTermiTime { get; set; }

        /// <summary>
        /// The total distance accumulated over all routes
        /// </summary>
        /// <value>The total distance accumulated over all routes</value>
        /// <example>100.0 km</example>
        [DataMember(Name = "totDistance", IsRequired = true, EmitDefaultValue = true)]
        public string TotDistance { get; set; }

        /// <summary>
        /// The total termiantion distance accumulated over all routes
        /// </summary>
        /// <value>The total termiantion distance accumulated over all routes</value>
        /// <example>100.0 km</example>
        [DataMember(Name = "totTermiDistance", IsRequired = true, EmitDefaultValue = true)]
        public string TotTermiDistance { get; set; }

        /// <summary>
        /// The jobViolations. The violation that occured on Job level. This does NOT contain individual node violations like lateness etc. Moreover,  it contains violations like relation-constraints between nodes. For example, node &#39;A&#39; needs to be visited before node &#39;B&#39; is violated.
        /// </summary>
        /// <value>The jobViolations. The violation that occured on Job level. This does NOT contain individual node violations like lateness etc. Moreover,  it contains violations like relation-constraints between nodes. For example, node &#39;A&#39; needs to be visited before node &#39;B&#39; is violated.</value>
        [DataMember(Name = "jobViolations", IsRequired = true, EmitDefaultValue = true)]
        public List<Violation> JobViolations { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolutionHeader {\n");
            sb.Append("  NumRoutes: ").Append(NumRoutes).Append("\n");
            sb.Append("  NumScheduledRoutes: ").Append(NumScheduledRoutes).Append("\n");
            sb.Append("  TotElements: ").Append(TotElements).Append("\n");
            sb.Append("  UnassignedElementIds: ").Append(UnassignedElementIds).Append("\n");
            sb.Append("  TotCost: ").Append(TotCost).Append("\n");
            sb.Append("  TotTime: ").Append(TotTime).Append("\n");
            sb.Append("  TotIdleTime: ").Append(TotIdleTime).Append("\n");
            sb.Append("  TotProdTime: ").Append(TotProdTime).Append("\n");
            sb.Append("  TotTranTime: ").Append(TotTranTime).Append("\n");
            sb.Append("  TotTermiTime: ").Append(TotTermiTime).Append("\n");
            sb.Append("  TotDistance: ").Append(TotDistance).Append("\n");
            sb.Append("  TotTermiDistance: ").Append(TotTermiDistance).Append("\n");
            sb.Append("  JobViolations: ").Append(JobViolations).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
