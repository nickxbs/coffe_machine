// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing

// Directories
let buildDir  = "./build/"
let testDir  = "./test/"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "Build" (fun _ ->
    !! "/**/*.fsproj"
    |> MSBuildDebug buildDir "Build" 
    |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    !! "/**/build/kata.dll"
    |> xUnit2 (fun p -> { p with HtmlOutputPath = Some ("./" @@ "xunit.html") })
)

// Build order
"Clean"
  ==> "Build"
  ==> "Test"

// start build
RunTargetOrDefault "Test"
