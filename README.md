# PGTA-Project2

///////////////////////////////////////////////////////////////////////////////////////
///										//////										///
///			P2 ASTERIX DECODER			//////		GENÍS CASTILLO Y ÀLEX RUIZ		///
///										//////										///
///////////////////////////////////////////////////////////////////////////////////////

1. Program installs as every other executable.
2. On the main screen we would have 4 buttons with 4 various functions:
	-Decode: It will ask you to select an asterix file to start the decode. After the decode you will be able to use the Export Data button to export the ASTERIX data into a CSV, the Show CSV button to quickly display the contents of the decode on a panel in the main program, Export CSV to export the decoded data into a CSV file and save it into the computer or use the last button to open the simulation environment with a map representation of the radar echoes.
	-Export data: Once an ASTERIX file has been selected by the DECODE button, you will be able to save all that data into a CSV file for a faster search and analysis.
	-Show CSV: It enables to select a generic CSV generated by the program beforehand and display it on screen for a faster analysis and error checking.
	-Open Simulation: After a succesfull ASTERIX decode, a map will open and we will have some setting to manage the entire simulation with the radar echoes overlayed on top.
3. Simulation: This is the most interesting screen because it will allow the users to quickly visualize the radar echoes in realtime overlayed in top of a real map. There are some buttons:
	-Advance: It allows the user to advance the simulation by 1 radar step (1 radar echo each 4s).
	-Reverse: Allows the user to retrocede a step in the simulation. Next to the button it is displayed the actual step of the simulation in seconds.
	-Init. Simulation: Starts the simulation in realtime (1 step every 4s).
	-Stop Simulation: Stops the simulation at the current step. Next to this button, the user will have some easy + and - buttons to increase or decrease the simulation speed with a parameter just below indicating the relative speed of the simulation with respect to realtime.
	-Export complete KML: Allowa the user to quickly export all the routes to a Google Earth compatible format. This allows to visualize all the complete routes with just a glance.
	-Generate Route: Allows the user to quickly isolate an aircraft and show only its route. Great way to visualize routes.