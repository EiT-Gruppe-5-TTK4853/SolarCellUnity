import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
from matplotlib.animation import FuncAnimation
from matplotlib.widgets import Slider
from scipy.spatial.transform import Rotation as R


def deg2rad(deg):
    return deg * 2 * np.pi / 360

# def Rzy(phi=0, theta=0, psi=0):
    # R = np.array([[np.cos(phi) * np.cos(theta),     np.sin(phi) * np.sin(theta) * np.cos(psi) - np.sin(phi) * ,    np.cos(phi) * np.sin(theta) * np.cos(psi) + np.sin(phi) * np.sin(psi)],
    #               [np.sin(psi) * np.cos(theta),    np.sin(phi) * np.sin(theta) * np.sin(psi),    np.sin(phi) * np.sin(theta)],
    #               [-np.sin(theta),    np.cos(theta) * np.sin(psi),              np.cos(theta)]])
    
    # R = np.array([[np.cos(phi) * np.cos(theta),     np.sin(phi),    np.cos(phi) * np.sin(theta)],
    #               [np.sin(phi) * np.cos(theta),    np.cos(phi),    np.sin(phi) * np.sin(theta)],
    #               [-np.sin(phi) * np.cos(theta),    0,              np.cos(theta)]])
    
    # assert abs(np.linalg.det(R) - 1) < 1e-5, f"The determinant is {np.linalg.det(R)}"
    # return R

# Phi is angle about z-axis, theta is angle about y-axis
psi = deg2rad(0)
theta = deg2rad(0)

# Define the components of the arrow direction
origin = np.array([0,0,0])

# Axis vectors
X = np.array([1, 0, 0])
Y = np.array([0, 1, 0])
Z = np.array([0, 0, 1])

axis = np.array([X, Y, Z])

euc_coordinate_frame = np.eye(3)
R = Rzy(psi, theta)
body_frame = R @ euc_coordinate_frame

ne =np.array([0, 0, 1]) 
nb = R @ ne
x = np.linspace(-1, 1, 3)
y = np.linspace(-1, 1, 3)
x, y = np.meshgrid(x, y)

ze = (-ne[0] * x - ne[1] * y) / ne[2]
zb = (-nb[0] * x - nb[1] * y) / nb[2]

# Create a 3D plot
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
plt.subplots_adjust(bottom=0.25)

def plot_origin(ax):
    # Plot axis and origin
    ax.quiver(*origin, axis[:,0], axis[:,1], axis[:,2], color='r', length=1)
    ax.quiver(*origin, *ne, color='g', length=2)
    ax.quiver(*origin, *nb, color='b', length=2)
    ax.scatter(*origin, color='c')

    # Plot the plane
    ax.plot_surface(x, y, ze, alpha=0.5, rstride=100, cstride=100, color='g')

    # Customize the plot
    ax.set_xlim([-4, 4])
    ax.set_ylim([-4, 4])
    ax.set_zlim([-4, 4])

    ax.set_xlabel('X-axis')
    ax.set_ylabel('Y-axis')
    ax.set_zlabel('Z-axis')

# Add sliders
def update_theta(t):
    global theta
    theta = deg2rad(t)
    update()

# Add sliders
def update_psi(t):
    global psi
    phi = deg2rad(t)
    update()

def update():
    R = Rzy(psi, theta)
    nb = R @ ne
    zb = (-nb[0] * x - nb[1] * y) / nb[2]
    
    ax.clear()
    # plot_origin(ax)
    ax.quiver(*origin, R[:,0], R[:,1], R[:,2], color='r', length=1)
    ax.plot_surface(x, y, zb, alpha=0.5, rstride=100, cstride=100, color='b')

ax_slider_theta = plt.axes([0.1, 0.1, 0.8, 0.1], facecolor='gray')
theta_slider = Slider(ax_slider_theta, 'Theta', valmin=-90, valmax=90, valinit=0, valstep=1)

ax_slider_psi = plt.axes([0.1, 0.0, 0.8, 0.1], facecolor='gray')
psi_slider = Slider(ax_slider_psi, 'Psi', valmin=-90, valmax=90, valinit=0, valstep=1)

theta_slider.on_changed(update_theta)
psi_slider.on_changed(update_psi)


plot_origin(ax)
ax.plot_surface(x, y, zb, alpha=0.5, rstride=100, cstride=100, color='b')

plt.show()