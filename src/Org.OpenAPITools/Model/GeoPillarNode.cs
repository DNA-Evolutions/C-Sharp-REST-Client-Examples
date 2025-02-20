/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (7.5.1-rc3-j17-SNAPSHOT)
 *
 * The version of the OpenAPI document: unknown
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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using FileParameter = Org.OpenAPITools.Client.FileParameter;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// GeoPillarNode
    /// </summary>
    [DataContract(Name = "GeoPillarNode")]
    public partial class GeoPillarNode : PillarType, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPillarNode" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GeoPillarNode() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPillarNode" /> class.
        /// </summary>
        /// <param name="attachedResourceId">The attached resourceId. A geoPillar must be visited by this resource..</param>
        /// <param name="onlyScheduledInCompany">The onlyScheduledInCompany.</param>
        /// <param name="connectionRelatedLateMargin">connectionRelatedLateMargin.</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;GeoPillarNode&quot;).</param>
        /// <param name="isForcedStayNode">The isForcedStayNode.</param>
        /// <param name="isSchedulableBeforeWorkingHours">The isSchedulableBeforeWorkingHours.</param>
        /// <param name="isOverwritingRouteStart">The boolean isOverwritingRouteStart. Instead of using the default start element of the route, the geoPillar will be used as so-called startAnchor..</param>
        /// <param name="isOverwritingRouteTermination">The boolean isOverwritingRouteTermination. Instead of using the default termination element of the route, the geoPillar will be used as so-called endAnchor..</param>
        /// <param name="isTimeAdjustableAnchor">The isTimeAdjustableAnchor.</param>
        /// <param name="isAutoTransformable2StartAnchor">The isAutoTransformable2StartAnchor.</param>
        /// <param name="isSchedulableAfterWorkingHours">The isSchedulableAfterWorkingHours.</param>
        public GeoPillarNode(string attachedResourceId = default(string), bool onlyScheduledInCompany = default(bool), ConnectionRelatedLateMargin connectionRelatedLateMargin = default(ConnectionRelatedLateMargin), string typeName = @"GeoPillarNode", bool isForcedStayNode = default(bool), bool isSchedulableBeforeWorkingHours = default(bool), bool isOverwritingRouteStart = default(bool), bool isOverwritingRouteTermination = default(bool), bool isTimeAdjustableAnchor = default(bool), bool isAutoTransformable2StartAnchor = default(bool), bool isSchedulableAfterWorkingHours = default(bool)) : base()
        {
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for GeoPillarNode and cannot be null");
            }
            this.TypeName = typeName;
            this.AttachedResourceId = attachedResourceId;
            this.OnlyScheduledInCompany = onlyScheduledInCompany;
            this.ConnectionRelatedLateMargin = connectionRelatedLateMargin;
            this.IsForcedStayNode = isForcedStayNode;
            this.IsSchedulableBeforeWorkingHours = isSchedulableBeforeWorkingHours;
            this.IsOverwritingRouteStart = isOverwritingRouteStart;
            this.IsOverwritingRouteTermination = isOverwritingRouteTermination;
            this.IsTimeAdjustableAnchor = isTimeAdjustableAnchor;
            this.IsAutoTransformable2StartAnchor = isAutoTransformable2StartAnchor;
            this.IsSchedulableAfterWorkingHours = isSchedulableAfterWorkingHours;
        }

        /// <summary>
        /// The attached resourceId. A geoPillar must be visited by this resource.
        /// </summary>
        /// <value>The attached resourceId. A geoPillar must be visited by this resource.</value>
        [DataMember(Name = "attachedResourceId", EmitDefaultValue = false)]
        public string AttachedResourceId { get; set; }

        /// <summary>
        /// The onlyScheduledInCompany
        /// </summary>
        /// <value>The onlyScheduledInCompany</value>
        [DataMember(Name = "onlyScheduledInCompany", EmitDefaultValue = true)]
        public bool OnlyScheduledInCompany { get; set; }

        /// <summary>
        /// Gets or Sets ConnectionRelatedLateMargin
        /// </summary>
        [DataMember(Name = "connectionRelatedLateMargin", EmitDefaultValue = false)]
        public ConnectionRelatedLateMargin ConnectionRelatedLateMargin { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        /*
        <example>GeoPillarNode</example>
        */
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// The isForcedStayNode
        /// </summary>
        /// <value>The isForcedStayNode</value>
        [DataMember(Name = "isForcedStayNode", EmitDefaultValue = true)]
        public bool IsForcedStayNode { get; set; }

        /// <summary>
        /// The isSchedulableBeforeWorkingHours
        /// </summary>
        /// <value>The isSchedulableBeforeWorkingHours</value>
        [DataMember(Name = "isSchedulableBeforeWorkingHours", EmitDefaultValue = true)]
        public bool IsSchedulableBeforeWorkingHours { get; set; }

        /// <summary>
        /// The boolean isOverwritingRouteStart. Instead of using the default start element of the route, the geoPillar will be used as so-called startAnchor.
        /// </summary>
        /// <value>The boolean isOverwritingRouteStart. Instead of using the default start element of the route, the geoPillar will be used as so-called startAnchor.</value>
        [DataMember(Name = "isOverwritingRouteStart", EmitDefaultValue = true)]
        public bool IsOverwritingRouteStart { get; set; }

        /// <summary>
        /// The boolean isOverwritingRouteTermination. Instead of using the default termination element of the route, the geoPillar will be used as so-called endAnchor.
        /// </summary>
        /// <value>The boolean isOverwritingRouteTermination. Instead of using the default termination element of the route, the geoPillar will be used as so-called endAnchor.</value>
        [DataMember(Name = "isOverwritingRouteTermination", EmitDefaultValue = true)]
        public bool IsOverwritingRouteTermination { get; set; }

        /// <summary>
        /// The isTimeAdjustableAnchor
        /// </summary>
        /// <value>The isTimeAdjustableAnchor</value>
        [DataMember(Name = "isTimeAdjustableAnchor", EmitDefaultValue = true)]
        public bool IsTimeAdjustableAnchor { get; set; }

        /// <summary>
        /// The isAutoTransformable2StartAnchor
        /// </summary>
        /// <value>The isAutoTransformable2StartAnchor</value>
        [DataMember(Name = "isAutoTransformable2StartAnchor", EmitDefaultValue = true)]
        public bool IsAutoTransformable2StartAnchor { get; set; }

        /// <summary>
        /// The isSchedulableAfterWorkingHours
        /// </summary>
        /// <value>The isSchedulableAfterWorkingHours</value>
        [DataMember(Name = "isSchedulableAfterWorkingHours", EmitDefaultValue = true)]
        public bool IsSchedulableAfterWorkingHours { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GeoPillarNode {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  AttachedResourceId: ").Append(AttachedResourceId).Append("\n");
            sb.Append("  OnlyScheduledInCompany: ").Append(OnlyScheduledInCompany).Append("\n");
            sb.Append("  ConnectionRelatedLateMargin: ").Append(ConnectionRelatedLateMargin).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
            sb.Append("  IsForcedStayNode: ").Append(IsForcedStayNode).Append("\n");
            sb.Append("  IsSchedulableBeforeWorkingHours: ").Append(IsSchedulableBeforeWorkingHours).Append("\n");
            sb.Append("  IsOverwritingRouteStart: ").Append(IsOverwritingRouteStart).Append("\n");
            sb.Append("  IsOverwritingRouteTermination: ").Append(IsOverwritingRouteTermination).Append("\n");
            sb.Append("  IsTimeAdjustableAnchor: ").Append(IsTimeAdjustableAnchor).Append("\n");
            sb.Append("  IsAutoTransformable2StartAnchor: ").Append(IsAutoTransformable2StartAnchor).Append("\n");
            sb.Append("  IsSchedulableAfterWorkingHours: ").Append(IsSchedulableAfterWorkingHours).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in base.BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
