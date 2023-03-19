
1. [OutPutCache (Duration = 30, varyByParam = "x; y;")]

Caches the operation for that period of time, if the same action got requested,
The Cached data will be shown. 

it's static by IP

VaryByParam => when the parameter changes, the request is made again. 


2. Custom Action Filters 
	
	- onActionExcuting
	- onActionExcuted
	- onResultExcuting
	- onResultExcuted

3. [NonAction]

=> Can't accessed by the url, used for logic inside the controller.

4.  [MyLogFilter]
        //[NonAction]
        //[ActionName("myDetails")]
        //[AcceptVerbs("GET","DELETE")]

5.  1- [Route("Register/emp")]

		then in resiterRoutes add => routes.MapMVCAttributeroutes();

6. setting [route("hm")] on the whole controller, 
means that every action need to assign a route for itself to be acessed.

=> I think this is because all of them would have the same route. 

7. [RoutePrefix("hm")] => now this must be included to the base url.

	Important Note: using this will remove the need to use [ActionName("")]