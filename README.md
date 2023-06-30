# 911-flappy-bird

Changelog:  

Alpha 2.1:  
After having our friends playtest the game on a school computer (lol), we've found certain things that need fixing.  
- One main bug we've discovered is that the speed in which the plane's gravity returns to normal after pressing LeftCtrl is framerate dependent.  
This bug was caused by an oversight in Plane.cs which was missing Time.delataTime. The updated code should provide an experience closer to what we intended.
  
**Old code:**  
```
if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.gravityScale = 10f;
        }

        if (rb.gravityScale > 1.5f)
        {
            rb.gravityScale -= 0.1f;
        }
```
**Fixed code:**  
```
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.gravityScale = 7f;
        }

        if (rb.gravityScale > 1.5f)
        {
            rb.gravityScale -= 10f * Time.deltaTime;
            //Debug.Log(rb.gravityScale);
        }

        if (rb.gravityScale < 1.5f)
        {
            rb.gravityScale = 1.5f;
        }
```

- Pressing space will now immediately set your gravity to 1.5 to cancel out LeftCtrl gravity's change
- Decreased Spawn Delay once again from 1.2 to 1.1
- Changed Hue of blue towers to make them stand out more

- While playtesting, I noticed that sometimes the blue pipes don't rotate, or rather their rotation is not noticable.  
This is because the rotation speed is randomly assigned a float from -20 to 20. Which could end up being a number close to 0 which makes the rotation not noticable.
  
**Old Code:**   
```
private float maxRot = 20;
private float maxSpeed = 10;

rotationSpeed = Random.Range(-maxSpeed, maxSpeed);
```
   
**Fixed Code:**   
```
    private float minSpeed = 5;
    private float maxSpeed = 12;

    private void Start()
    {
        rotationAngle = Random.Range(-rot, rot);
        rotationAngle = rotationAngle * RandomPolarity();

        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        rotationSpeed = rotationSpeed * RandomPolarity();
    }

    private static int RandomPolarity()
    {
        if (Random.Range(1, 3) == 1) //1 to 2
            return -1;
        else 
            return 1;
    }
```
  
The rotation speed should now be from either -12 to -5 or 5 to 12.  
Same goes for the green towers however I haven't fixed it.

Also the blue towers lag on other people's machine but it works fine on mine so HiddenKendo pls fix I have no idea what I'm doing lol
  
  
Alpha 2:  
- Increased Spawn Delay from 0.9 to 1.2
- Changed sprite for green towers
- Green towers can now move down
- Increased gravity change with LeftCtrl from 8 to 10

Alpha 1:  
- Decreased Spawn Delay from 1 to 0.9
- Added Blue Towers which tilt either left or right at a random speed
- Added Green Towers which slowly moves up
- Blue Towers and Green Towers have a lower spawn rate than normal towers
