/*
 * DNA Evolutions - JOpt.TourOptimizer
 *
 * This is DNA's JOpt.TourOptimizer service. A RESTful Spring Boot application using springdoc-openapi and OpenAPI 3. JOpt.TourOpptimizer is a service that delivers route optimization and automatic scheduling features to be easily integrated into any third-party application. JOpt.TourOpptimizer encapsulates all necessary optimization functionality and provides a comprehensive REST API that offers a domain-specific optimization interface for the transportation industry. The service is stateless and does not come with graphical user interfaces, map depiction or any databases. These extensions and adjustments are supposed to be introduced by the consumer of the service while integrating it into his/her own application. The service will allow for many suitable adjustments and user-specific settings to adjust the behaviour and optimization goals (e.g. minimizing distance, maximizing resource utilization, etc.) through a comprehensive set of functions. This will enable you to gain control of the complete optimization processes.This service is based on JOpt (null)
 *
 * The version of the OpenAPI document: 1.2.2-SNAPSHOT
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
    /// ConnectedConstraint
    /// </summary>
    [DataContract(Name = "ConnectedConstraint")]
    [JsonConverter(typeof(JsonSubtypes), "TypeName")]
    [JsonSubtypes.KnownSubType(typeof(AbsoluteNodeColorMultiRouteConstraint), "AbsoluteNodeColorMultiRouteConstraint")]
    [JsonSubtypes.KnownSubType(typeof(BindingResourceConstraint), "BindingResource")]
    [JsonSubtypes.KnownSubType(typeof(ConnectedConstraint), "ConnectedConstraint")]
    [JsonSubtypes.KnownSubType(typeof(ExcludingResourceConstraint), "ExcludingResource")]
    [JsonSubtypes.KnownSubType(typeof(NodeColorMultiRouteConstraint), "NodeColorMultiRouteConstraint")]
    [JsonSubtypes.KnownSubType(typeof(ResourceLocationConstraint), "ResourceLocationConstraint")]
    [JsonSubtypes.KnownSubType(typeof(TypeConstraint), "Type")]
    [JsonSubtypes.KnownSubType(typeof(TypeWithExpertiseConstraint), "TypeWithExpertise")]
    [JsonSubtypes.KnownSubType(typeof(UKPostCodeConstraint), "UKPostCodeConstraint")]
    [JsonSubtypes.KnownSubType(typeof(ZoneNumberConstraint), "ZoneNumberConstraint")]
    public partial class ConnectedConstraint : ConstraintType, IEquatable<ConnectedConstraint>, IValidatableObject
    {
        /// <summary>
        /// The connectionType
        /// </summary>
        /// <value>The connectionType</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ConnectionTypeEnum
        {
            /// <summary>
            /// Enum ANDCONNECTIONTYPE for value: AND_CONNECTION_TYPE
            /// </summary>
            [EnumMember(Value = "AND_CONNECTION_TYPE")]
            ANDCONNECTIONTYPE = 1,

            /// <summary>
            /// Enum ORCONNECTIONTYPE for value: OR_CONNECTION_TYPE
            /// </summary>
            [EnumMember(Value = "OR_CONNECTION_TYPE")]
            ORCONNECTIONTYPE = 2

        }


        /// <summary>
        /// The connectionType
        /// </summary>
        /// <value>The connectionType</value>
        [DataMember(Name = "connectionType", IsRequired = true, EmitDefaultValue = false)]
        public ConnectionTypeEnum ConnectionType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectedConstraint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConnectedConstraint() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectedConstraint" /> class.
        /// </summary>
        /// <param name="constraintOne">constraintOne (required).</param>
        /// <param name="constraintTwo">constraintTwo (required).</param>
        /// <param name="connectionType">The connectionType (required).</param>
        /// <param name="typeName">The typeName of the object (required) (default to &quot;ConnectedConstraint&quot;).</param>
        public ConnectedConstraint(Constraint constraintOne = default(Constraint), Constraint constraintTwo = default(Constraint), ConnectionTypeEnum connectionType = default(ConnectionTypeEnum), string typeName = "ConnectedConstraint") : base()
        {
            // to ensure "constraintOne" is required (not null)
            if (constraintOne == null)
            {
                throw new ArgumentNullException("constraintOne is a required property for ConnectedConstraint and cannot be null");
            }
            this.ConstraintOne = constraintOne;
            // to ensure "constraintTwo" is required (not null)
            if (constraintTwo == null)
            {
                throw new ArgumentNullException("constraintTwo is a required property for ConnectedConstraint and cannot be null");
            }
            this.ConstraintTwo = constraintTwo;
            this.ConnectionType = connectionType;
            // to ensure "typeName" is required (not null)
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName is a required property for ConnectedConstraint and cannot be null");
            }
            this.TypeName = typeName;
        }

        /// <summary>
        /// Gets or Sets ConstraintOne
        /// </summary>
        [DataMember(Name = "constraintOne", IsRequired = true, EmitDefaultValue = false)]
        public Constraint ConstraintOne { get; set; }

        /// <summary>
        /// Gets or Sets ConstraintTwo
        /// </summary>
        [DataMember(Name = "constraintTwo", IsRequired = true, EmitDefaultValue = false)]
        public Constraint ConstraintTwo { get; set; }

        /// <summary>
        /// The typeName of the object
        /// </summary>
        /// <value>The typeName of the object</value>
        [DataMember(Name = "typeName", IsRequired = true, EmitDefaultValue = false)]
        public string TypeName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConnectedConstraint {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  ConstraintOne: ").Append(ConstraintOne).Append("\n");
            sb.Append("  ConstraintTwo: ").Append(ConstraintTwo).Append("\n");
            sb.Append("  ConnectionType: ").Append(ConnectionType).Append("\n");
            sb.Append("  TypeName: ").Append(TypeName).Append("\n");
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
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ConnectedConstraint);
        }

        /// <summary>
        /// Returns true if ConnectedConstraint instances are equal
        /// </summary>
        /// <param name="input">Instance of ConnectedConstraint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConnectedConstraint input)
        {
            if (input == null)
            {
                return false;
            }
            return base.Equals(input) && 
                (
                    this.ConstraintOne == input.ConstraintOne ||
                    (this.ConstraintOne != null &&
                    this.ConstraintOne.Equals(input.ConstraintOne))
                ) && base.Equals(input) && 
                (
                    this.ConstraintTwo == input.ConstraintTwo ||
                    (this.ConstraintTwo != null &&
                    this.ConstraintTwo.Equals(input.ConstraintTwo))
                ) && base.Equals(input) && 
                (
                    this.ConnectionType == input.ConnectionType ||
                    this.ConnectionType.Equals(input.ConnectionType)
                ) && base.Equals(input) && 
                (
                    this.TypeName == input.TypeName ||
                    (this.TypeName != null &&
                    this.TypeName.Equals(input.TypeName))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.ConstraintOne != null)
                {
                    hashCode = (hashCode * 59) + this.ConstraintOne.GetHashCode();
                }
                if (this.ConstraintTwo != null)
                {
                    hashCode = (hashCode * 59) + this.ConstraintTwo.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ConnectionType.GetHashCode();
                if (this.TypeName != null)
                {
                    hashCode = (hashCode * 59) + this.TypeName.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }

}
