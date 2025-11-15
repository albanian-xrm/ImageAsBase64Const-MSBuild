> Copyright 2025 AlbanianXrm <albanian@xrm.al>
> 
> Licensed under the Apache License, Version 2.0 (the "License");
> you may not use this file except in compliance with the License.
> You may obtain a copy of the License at
> 
>     http://www.apache.org/licenses/LICENSE-2.0
> 
> Unless required by applicable law or agreed to in writing, software
> distributed under the License is distributed on an "AS IS" BASIS,
> WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
> See the License for the specific language governing permissions and
> limitations under the License.

# AlbanianXrm.ImageAsBase64ConstGenerator.MSBuild

This MSBuild package can convert the referenced Image files to Base64 string constants in your application. You need to specify the details of the generated code in a `None` item and it will be picked up by the custom task.
Simple usage example:


```xml
<?xml version="1.0" encoding="utf-8"?>
<Project>
	<ItemGroup>
		<None Update="Resources\ShkoOnline32x32.png">
			<Namespace>ShkoOnline.DataverseExcelReporter</Namespace>
			<ClassName>Resources</ClassName>
			<ImageAsBase64Const>ShkoOnline32x32</ImageAsBase64Const>
		</None>
	</ItemGroup>
	<ItemGroup>
		<PackageReference Include="AlbanianXrm.ImageAsBase64ConstGenerator.MSBuild" Version="1.0.0" PrivateAssets="All" />
	</ItemGroup>
</Project>
```

The previous example will generate a class named `Resources` in the `ShkoOnline.DataverseExcelReporter` namespace with a constant string property named `ShkoOnline32x32` containing the Base64 representation of the image.
