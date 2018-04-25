# Generic Unity Object Pooler
An easy to use object-pooler which is efficient and quick to set-up.

# What is pooling? 
It is computationally expensive to instantiate and destroy objects like bullets that get re-used a lot.
Its a lot more effective to instantiate them all in the beginning and to keep re-using them by setting them active/false

This script can act as a pooling control hub, it will create all pooled objects you need at the start and objects can be called as and when needed by other scripts.

# How to use?
1) Create a new empty GameObject.
2) Create a new script called ObjectPooler
3) Replace the contents of ObjectPooler with contents of the ObjectPooler script that can be found in this repo.
4) Attach the script to the GameObject you created.
5) In the inspector, in the script component, enter the number of gameObjects you want pooled and then add their prefabs to the list.
6) Increase Amount to Pool to at least 1. If you are unsure how many objects of this type you will need, check the 'should expand' box.
7) Get the gameObject by using 
```
GameObject GO = ObjectPooler.SharedInstance.GetPooledObject(0);
 // (Instead of instantiating a new one.)
```


8) Make sure that the gameObject you are re-using does infact get disabled naturally after a while.
(Otherwise there is no point of pooling)
9) When you just get the object from the pooler, it will be disabled, remember to set it to active.

If you still have doubts, you can try running the sample scene included in the package. 
Simply download the pooler package then choose to import a custom package from unity, select the downloaded package and navigate to the scene called BallThrow where you can press the spacebar to get lots of object-pooled balls that disable after 5 seconds.

# Public functions

Assuming you stored a reference to the objectpooler in a variable called OP. 
```
ObjectPooler OP;
void Awake(){
  OP = ObjectPooler.SharedInstance;
}
```
1) Getting an object:
```
GameObject GO = OP.GetPooledObject(0); // 0 is the index of the object you want
```
2) Getting all gameobjects of a type:
```
List<GameObject> objects = OP.GetAllPooledObjects(0); // 0 is the index of the object you want
 ```
3) Adding a new object during gameplay:
 ```
int indexOfThisObj = OP.AddObject(gameObj, amt, true);

// where gameObj is the gameobject you want to pool
// amt is an int specifying how many copies you want in the pool
// third argument is a bool which specifies whether this object's pool can expand
 ```
This gameObject can be accessed by using:
```
GameObject GO = OP.GetPooledObject(indexOfThisObj);
```
