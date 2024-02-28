import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
from matplotlib.animation import FuncAnimation

# Set the size of the grid
x = np.linspace(-1, 1, 3)
y = np.linspace(-1, 1, 3)
x, y = np.meshgrid(x, y)

# The position of the sun
sun = np.array([3, 3, 3])

# Plane
# n = np.array([1, 0, 1])
n = sun
n = n / np.linalg.norm(n) 
z = (-n[0] * x - n[1] * y) / n[2]

# Create a 3D plot
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

# Axis vectors
X = np.array([1, 0, 0])
Y = np.array([0, 1, 0])
Z = np.array([0, 0, 1])

axis = np.array([X, Y, Z])

# Define the components of the arrow direction
origin = np.array([0,0,0])

# Plot axis and origin
ax.quiver(*origin, axis[:,0], axis[:,1], axis[:,2], color='r', length=1)
ax.quiver(*origin, *n, color='b', length=2)
ax.scatter(*origin, color='c')
ax.scatter(*sun, color='y')

# Plot the plane
ax.plot_surface(x, y, z, alpha=0.5, rstride=100, cstride=100, color='b')

# Customize the plot
ax.set_xlim([-4, 4])
ax.set_ylim([-4, 4])
ax.set_zlim([-4, 4])

ax.set_xlabel('X-axis')
ax.set_ylabel('Y-axis')
ax.set_zlabel('Z-axis')
ax.set_title('3D Arrow Plot')

# Show the plot
plt.show()