# F10Y.L0000
.NET Standard 2.1 foundation library.

The generally-applicable, unopinionated, netstandard2.1, C#/.NET foundation library.


## Instance Set Descriptor

Domain Set:
	.NET
	C#

Instance Variety Descriptor (Aggregation, count: 3)
	Functions: instance variety name
	Values: instance variety name
	UtilityTypes: instance variety name

F10Y: organization name
Public: visibility

netstandard2.1: target framework moniker

F10Y.L0000: dependency leaf context
F10Y.T0002: dependency descriptor name
F10Y.T0003: dependency descriptor name
F10Y.T0004: dependency descriptor name
F10Y.Y0000: dependency descriptor name
: dependency descriptors

General: applicability
Unopinionated: opinion


## Instance Varieties

Allowed:

- Functions
- Utility Types (but no Data Types)
- Values

Disallowed: All others, including:

- Data Types (Utility Types are allowed)
- Executables (Scripts, Demonstrations, Experiments, Explorations; these are in the associated Construction project, or better, in the central scripts project)

- Service Definitions and Implementations
- IHasX/IWithX types
- Razor Components
- Database entities
- Marker Types


## Allowed Dependencies

The allowed dependencies are FIXED. No changes allowed.

- netstandard2.1: target framework
- Marker attribute types libraries:
	- F10Y.T0003 - Values Marker
	- F10Y.T0002 - Functions Marker
	- F10Y.T0004 - Types Marker (for utility types ONLY)
	- F10Y.T0000 - Markers
- Documentation:
	- F10Y.Y0000 - .NET documentations
	- F10Y.T0001 - Documentations Marker


## Opinions

Allowed Opinions:

- Unopinionated


Disallowed Opinions:

- Organizational
- Personal
- Context Based
- IHasX/IWithX Based
- Service Based


## Internal Structure

Because this library is so strictly specified, this library follows a single project approach (with no multi-library project internal structure).
