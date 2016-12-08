Player activator script
---------------------------
To Use PlayerActivator:

1. Unpack into Assets folder
2. Drag PlayerActivator script onto FPSController

The PlayerActivator script can only activate an object that has: 
- has a Monobehaviour that inherits the Activate() method from the Activatable interface
- has a collider!

This is an example of a lever that toggles a light.

public class Hebel : MonoBehaviour, Activatable {
    public Light l;

    public void Activate()
    {
        l.enabled = !l.enabled;
    }
}

Just write any custom behaviour into the Activate() method. This method is called 
once when the player clicks this object.

Jean-Luc