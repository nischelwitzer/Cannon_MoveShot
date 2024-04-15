# Cannon_MoveShot Force, Move 
Cannon Move and Shot Example [^1].

1. Cannon Movement (old InputSystem)
1. Ball as Prefab

> [!TIP]
> "Ball" Prefab destroys himself.
> When destroyed no "Sound" is available for playing!
   
## Main Code

Movement of the Object (Cannon):

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
