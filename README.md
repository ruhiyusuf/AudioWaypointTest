# AudioWaypointTest

Transition between different soundtracks based on object collisions. 

- Create cube objects for each transition and an empty AudioDJ object to keep track of global variables.

<img width="268" alt="Screen Shot 2022-11-24 at 12 34 54 AM" src="https://user-images.githubusercontent.com/77863500/203732921-8cab2c13-fc93-4d2c-871d-3ba782b87236.png">

- For each transition cube object, attach `Trigger.cs` and **Mesh Collider** as a component. Add 2 **Audio Source** components, one for the transition music and one for the actual soundtrack.
- Link the two audioclips to the `Trigger.cs` script in the **Inspector**.

