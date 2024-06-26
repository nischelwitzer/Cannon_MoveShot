# Cannon_MoveShot Force, Move aka "Brick Shooter"
Cannon Move and Shot Example [^1] and [^2].

1. Cannon Movement (done with the old Unity InputSystem)
1. create a small Ball as "Prefab"
2. Shooting
   - clone the prefab with: *Instantiate*
   - add the shoot power: *AddForce* (in the correct direction)

You can find the [whole code here](./scripts/MoveAndShot.cs)!

<img src="./cannon_shot.png" widht="500">

> [!TIP]
> "Ball" Prefab destroys himself.
> When destroyed no "Sound" is available for playing!
   
## Main Code in Script: MoveAndShot.cs

Movement of the Object (Cannon) [see the MoveAndShot.cs Script](./scripts/MoveAndShot.cs):

```
float h = Input.GetAxis("Horizontal"); // gamepad 
float v = Input.GetAxis("Vertical");

Vector3 myRotate = new Vector3(v * 40.0F+0.0F-20F, h * 60.0F, 0.0F); // more left/right (60)
transform.rotation =  Quaternion.Euler(myRotate); 

if (Input.GetButtonUp("Fire1")) myShot();
```

Shot by "Fire". Use Ball-Prefab with "DestroyMe" (see Scripts).

```
Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody; 
shot.AddForce(shotPos.forward * shotForce);
```

### Notes

[^1]: Code from 2021: \01_unity\2021_dmt3\ex06_force_shot\Assets\04_force
[^2]: and \01_unity\2021_dmt3\ex00_code_examples\Assets\04_force

