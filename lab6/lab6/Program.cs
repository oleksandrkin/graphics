﻿using Tao.OpenGl;
using Tao.FreeGlut;

namespace lab6
{
    sealed class Program
    {
        static float X = 0.0f;		
        static float Y = 0.0f;		
        static float Z = 0.0f;		
        static float rotX = 0.0f;	
        static float rotY = 0.0f;	
        static float rotZ = 0.0f;	

        static float rotLx = 0.0f;   
        static float rotLy = 0.0f;   
        static float rotLz = 0.0f;   

        static bool lines = true;      
        static bool rotation = false;   // Rotate if F2 is pressed   

        static void Drawings()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();								
            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);			
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);			
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);		

            if (rotation) 
            {
                rotX += 0.2f;
                rotY += 0.2f;
                rotZ += 0.2f;
            }

            Gl.glTranslatef(X, Y, Z);		

            if (lines)
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3f(0.0f, 1.0f, 0.0f);			    // Green for x axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(10f, 0f, 0f);

                Gl.glColor3f(1.0f, 0.0f, 0.0f);				// Red for y axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 10f, 0f);

                Gl.glColor3f(0.0f, 0.0f, 1.0f);				// Blue for z axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, 10f);
                Gl.glEnd();

                Gl.glEnable(Gl.GL_LINE_STIPPLE);				
                Gl.glLineStipple(1, 0x0101);		    	

                Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3f(0.0f, 1.0f, 0.0f);			        // Green for x axis
                Gl.glVertex3f(-10f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, 0f);

                Gl.glColor3f(1.0f, 0.0f, 0.0f);				    // Red for y axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, -10f, 0f);

                Gl.glColor3f(0.0f, 0.0f, 1.0f);				    // Blue for z axis
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, -10f);
                Gl.glEnd();
                Gl.glDisable(Gl.GL_LINE_STIPPLE);
            }

            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);

            // 1 - 2
            Gl.glVertex3f(5f, 0f, 4f);
            Gl.glVertex3f(5f, -3f, 0f);

            // 1 - 3
            Gl.glVertex3f(5f, 0f, 4f);
            Gl.glVertex3f(5f, 3f, 0f);

            // 1 - 5
            Gl.glVertex3f(5f, 0f, 4f);
            Gl.glVertex3f(-5f, 0f, 4f);

            // 2 - 3
            Gl.glVertex3f(5f, -3f, 0f);
            Gl.glVertex3f(5f, 3f, 0f);

            // 2 - 4
            Gl.glVertex3f(5f, -3f, 0f);
            Gl.glVertex3f(5f, 0f, -4f);

            // 2 - 6
            Gl.glVertex3f(5f, -3f, 0f);
            Gl.glVertex3f(-5f, -3f, 0f);

            // 3 - 4
            Gl.glVertex3f(5f, 3f, 0f);
            Gl.glVertex3f(5f, 0f, -4f);

            // 3 - 7
            Gl.glVertex3f(5f, 3f, 0f);
            Gl.glVertex3f(-5f, 3f, 0f);

            // 4 - 8
            Gl.glVertex3f(5f, 0f, -4f);
            Gl.glVertex3f(-5f, 0f, -4f);

            // 5 - 6
            Gl.glVertex3f(-5f, 0f, 4f);
            Gl.glVertex3f(-5f, -3f, 0f);

            // 5 - 7
            Gl.glVertex3f(-5f, 0f, 4f);
            Gl.glVertex3f(-5f, 3f, 0f);

            // 6 - 7
            Gl.glVertex3f(-5f, -3f, 0f);
            Gl.glVertex3f(-5f, 3f, 0f);

            // 6 - 8
            Gl.glVertex3f(-5f, -3f, 0f);
            Gl.glVertex3f(-5f, 0f, -4f);

            // 7 - 8
            Gl.glVertex3f(-5f, 3f, 0f);
            Gl.glVertex3f(-5f, 0f, -4f);

            Gl.glEnd();

            Glut.glutPostRedisplay();	                    // Redraw the scene
            Gl.glPopMatrix();							    // Don't forget to pop the Matrix
            Glut.glutSwapBuffers();
        }

        static void Init()
        {
            Gl.glShadeModel(Gl.GL_SMOOTH);                
            Gl.glClearColor(0, 0, 0, 0.0f);               
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);    
            Gl.glClearDepth(1.0f);          
            Gl.glEnable(Gl.GL_DEPTH_TEST); 
            Gl.glDepthFunc(Gl.GL_LEQUAL);   
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
        }

        static void Reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);				
            Gl.glMatrixMode(Gl.GL_PROJECTION);	
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.10f, 500.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(rotLx, rotLy, 15.0f + rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        private static void Keyboard(byte key, int x, int y)
        {
            switch (key)
            {
                // x,X,y,Y,z,Z uses the glRotatef() function
                case 120:	// x 			// Rotates screen on x axis 
                    rotX -= 2.0f;
                    break;
                case 88:	// X			// Opposite way 
                    rotX += 2.0f;
                    break;
                case 121:	// y		    // Rotates screen on y axis
                    rotY -= 2.0f;
                    break;
                case 89:	// Y			// Opposite way
                    rotY += 2.0f;
                    break;
                case 122:	// z			// Rotates screen on z axis
                    rotZ -= 2.0f;
                    break;
                case 90:	// Z			// Opposite way
                    rotZ += 2.0f;
                    break;

                case 98:    // b		// Rotates on x axis by -90 degree
                    rotX -= 90.0f;
                    break;
                case 66:	// B		// Rotates on y axis by 90 degree
                    rotX += 90.0f;
                    break;
                case 110:	// n		// Rotates on y axis by -90 degree
                    rotY -= 90.0f;
                    break;
                case 78:	// N		// Rotates on y axis by 90 degree
                    rotY += 90.0f;
                    break;
                case 109:	// m		// Rotates on z axis by -90 degree
                    rotZ -= 90.0f;
                    break;
                case 77:	// M		// Rotates on z axis by 90 degree
                    rotZ += 90.0f;
                    break;
                case 111:	// o		// Resets all parameters
                case 80:    // O	    // Displays the cube in the starting position
                    rotation = false;
                    X = Y = 0.0f;
                    Z = 0.0f;
                    rotX = 0.0f;
                    rotY = 0.0f;
                    rotZ = 0.0f;
                    rotLx = 0.0f;
                    rotLy = 0.0f;
                    rotLz = 0.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(rotLx, rotLy, 15.0f + rotLz, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
                    break;
            }
            Glut.glutPostRedisplay();	// Redraw the scene
        }

        static void ProcessMouseWheel(int wheel, int direction, int x, int y)
        {
            Z += direction;  // Adjust the Z value 
            Glut.glutPostRedisplay();
        }

        static void Main(string[] args)
        {
            Glut.glutInit();        
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);		   
            Glut.glutInitWindowSize(600, 600);						              
            Glut.glutCreateWindow("Lab 6");
            Init();
            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Drawings);
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));          
            Glut.glutMouseWheelFunc(new Glut.MouseWheelCallback(ProcessMouseWheel));
            Glut.glutMainLoop();
        }
    }
}
