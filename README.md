# Esri CloudXR Demo

![image](arcgis-maps-sdk-unity-samples.png)

Here is a VR demo developed by ESRI within the Unity Engine. It is built off the [ArcGIS SDK Unity VRSample](https://github.com/Esri/arcgis-maps-sdk-unity-samples/tree/main/samples_project/Assets/SampleViewer/Samples/VRSample), incorporating more interaction and diverse features in order to utilize the demo in tandem with [Nvidia’s CloudXR Application](https://developer.nvidia.com/cloudxr-sdk). The main branch is configured to work with our ArcGIS plugin version 1.3.0. If you would like to build the application to a VR headset you would need to switch to the URPBuild branch since Android does not support the HD Rendering Pipeline we use in the main branch.

## Features
* Continuous viewing and movement in 8 cardinal directions.
* Choice between continuous or snap turning.
* Ability to explore 7 unique real world locations, showcasing Esri data and map components.
* Ability to change the time of day, and therefore the lighting.
* Ability to change weather components from sunny to rainy.
* Ability to select a surface on the map to get the address of that location.

## Instructions

1. Clone this repo.
2. Refer to the [ArcGIS Maps SDK for Unity's documentation on getting started](https://developers.arcgis.com/unity/get-started/) on how to download `Unity` and the `ArcGIS Maps SDK for Unity`.
3. Open the project in Unity ignoring the errors when prompted to enter `Safe Mode`.
4. Use the package manager to import the `.tarball` downloaded in step 2.

![image](package-manager.png)

5. Import the samples. These samples include some components necessary for this repo to function including the `ArcGIS Camera Controller` component.

![image](import-samples.png)

6. If there are still errors, locate the ArcGISMapsSDK Assembly Definition within the folder `Assets -> Samples -> ArcGIS Maps SDK for Unity -> 1.3.0 -> Sample Content -> Arc GIS Maps SDK.Samples (asmdef)` and add the `Unity.InputSystem` asmdef to the references. Make sure to click *Apply* at the bottom.

7. Launch Unity and open the `VR Sample` level.

8. In the hierarchy select the `ArcGISMap` Game Object. In the inspector set the API key on the ArcGISMap Component. You can learn more about [API keys](https://developers.arcgis.com/documentation/mapping-apis-and-services/security/api-keys/) and [Accounts](https://developers.arcgis.com/documentation/mapping-apis-and-services/deployment/accounts/) in the _Mapping APIs and location services_ guide.

9. (Optional) If you want to be able to open the `.cs` files in this project and have intellisense recognize variable correctly, in Unity navigate to `Edit -> Preferences -> External Tools -> Generate .csproj files for 'local tarball`

## Requirements

* Refer to the [ArcGIS Maps SDK for Unity's documentation on system requirements](https://developers.arcgis.com/unity/reference/system-requirements/)

## Resources

* [ArcGIS Maps SDK for Unity's documentation](https://developers.arcgis.com/unity/)
* [Unity's documentation](https://docs.unity.com/)
* [Esri Community forum](https://community.esri.com/t5/arcgis-maps-sdks-for-unity-questions/bd-p/arcgis-maps-sdks-unity-questions)

## Issues

Find a bug or want to request a new feature?  Please let us know by submitting an issue.

## Contributing

Esri welcomes contributions from anyone and everyone. Please see our [guidelines for contributing](https://github.com/esri/contributing).

## Licensing
Copyright 2023 Esri

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

A copy of the license is available in the repository's [license.txt]( https://raw.github.com/Esri/arcgis-maps-sdk-unity-samples/master/license.txt) file.
